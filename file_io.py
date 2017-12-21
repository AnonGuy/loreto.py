# Copyright 2017, Jeremiah Boby, All rights reserved.

import os
import sys
from getpass import getpass

folder = 'modules/'
modules = os.listdir(folder)

for module in modules:
    sys.path.append(folder+module)

import requests

with open('loreto_data/auth','r') as fh:
    content = fh.read().strip()
content = content.split("\n")

unf  = (content[0],
        content[1])

url     = 'https://e.loreto.ac.uk/extranet-7.9/login.aspx'

payload = {        
        '__EVENTTARGET'        : '',
        '__EVENTARGUMENT'      : '',
        '__VIEWSTATE'          : '/wEPDwUKMTUzNTQ2OTI1MGQYAgUeX19Db250cm9sc1JlcXVpcmVQb3N0QmFja0'
                                 'tleV9fFgIFF2N0bDAwJGN0bDExJGN0bDAyJGN0bDAxBRdjdGwwMCRjdGwxMSRj'
                                 'dGwwMiRjdGwwMwULY3RsMDAkY3RsMTEPD2QCAWQiZUS2TLiCkVxYZ1Uk7uQwnS'
                                 'dp4TH0gWFSmysg8qKLFw==',
        '__VIEWSTATEGENERATOR' : '48197344',
        '__EVENTVALIDATION'    : '/wEdAAX557L4PskjwHDA//oUkwYHevVvFwfHkeeY3hsFyLZVyO1NsodTRZU5H1'
                                 'OyI03zVPbXq2eayQar80MYq419oMqi9ms/j/llou8iY+ln/nknFC0pOX1t+g35'
                                 'y+zso/0c+1CN3eG9EdMMW19+Pgt4rhew',
        'ctl00$body$username'  : unf[0],
        'ctl00$body$password'  : unf[1],
        'ctl00$body$login'     : 'Login'}

session = requests.Session()
sauce   = session.post(url, data=payload)

def dnld(inp):
    dld  = 'https://e.loreto.ac.uk/extranet-7.9/Download/N/'
    pth    = dld+(inp.replace(':',''))
    pth    = pth.replace('\\','/')
    ext    = pth.split('/')[-1]
    fle    = session.get(pth)
    open('downloads/'+ext,'wb').write(fle.content)
    return fle

def upld(inp):
    fle = {'userfile[]':open(inp, 'rb')}
    uld = 'https://e.loreto.ac.uk/extranet-7.9/uploadh.aspx?path=N'
    res = session.post(uld,data={
        'upload_type': 'standard',
        'upload_to': '0'}, files=fle)
    return res

def uhex(inp,name):
    import base64
    image = open('downloads/'+name, 'wb')
    unhex = base64.decodestring(inp.encode())
    image.write(unhex)
