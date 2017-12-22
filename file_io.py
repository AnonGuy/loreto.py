# Copyright 2017, Jeremiah Boby, All rights reserved.

import os
import sys
from getpass import getpass

try:
    curDir = sys.argv[1]
    usName = sys.argv[2]
    usPswd = sys.argv[3]
except:
    curDir = os.getcwd()+'/'
    usName = input("Enter username: ")
    usPswd = getpass("Enter password: ")

folder = curDir+'/modules/'
modules = os.listdir(folder)

if not os.path.exists(curDir+'/loreto_data/auth'):
    with open(curDir+'/loreto_data/auth','w+') as fh:
        fh.write(usName+'\n')
        fh.write(usPswd)

for module in modules:
    sys.path.append(folder+module)

import requests

with open(curDir+'loreto_data/auth','r') as fh:
    content = fh.read().strip()

content = content.split("\n")

unf  = (content[0],
        content[1])

url     = 'https://e.loreto.ac.uk/extranet-7.9/login.aspx'

payload = {
        'ctl00$body$username'  : unf[0],
        'ctl00$body$password'  : unf[1],
        
        '__EVENTVALIDATION'    : '/wEdAAQmeso2J1PoHxrQ49Q'
                                 'XdzmH7U2yh1NFlTkfU7IjTf'
                                 'NU9terZ5rJBqvzQxirjX2gy'
                                 'qL2az+P+WWi7yJj6Wf+eScU'
                                 'dz+RQsgUIMoHq9ekJPcfNcX'
                                 'Z5iV4N9A3nPHPjkFi6Ao=',
        
        '__VIEWSTATE'          : '/wEPDwUKMTUzNTQ2OTI1MGR'
                                 'kBWYBsd8F5NALKOmLqiDX2X'
                                 '1Y/71HzWfqYLeawg4MvMs=',
        
        'ctl00$body$login'     : 'Login',       
        }

session = requests.Session()
sauce   = session.post(url, data=payload)

def dnld(inp):
    dld  = 'https://e.loreto.ac.uk/extranet-7.9/Download/N/'
    pth    = dld+(inp.replace(':',''))
    pth    = pth.replace('\\','/')
    ext    = pth.split('/')[-1]
    fle    = session.get(pth)
    open(curDir+'downloads/'+ext,'wb').write(fle.content)
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
    image = open(curDir+'downloads/'+name, 'wb')
    unhex = base64.decodestring(inp.encode())
    image.write(unhex)
