# Copyright 2017, Jeremiah Boby, All rights reserved.

import os
import re
import sys
from file_io import *
from getpass import getpass

folder = 'modules/'
modules = os.listdir(folder)

for module in modules:
    sys.path.append(folder+module)

import requests

usr_info = []

if not os.path.exists('loreto_data/auth'):
    with open('loreto_data/auth','w+') as fh:
        fh.write(input('Username: ')+'\n')
        fh.write(input('Password: '))

with open('loreto_data/auth','r') as fh:
    content = fh.read().strip()
    
content = content.split('\n')

key = (content[0],
       content[1])

usr_info.append([key[0],key[1]])

def dump(sep):
    with open('loreto_data/dump','w+') as file:
        for line in usr_info:
            file.write(sep.join(line)+'\n')
            

request   = requests.post('http://my.loreto.ac.uk',auth=key)

match     = re.compile(r'<h4>Your  *?(.+?)<a data-week-beginning',flags=re.S)
raw_table = match.search(request.text).group()

userp     = re.compile(r'<img id="studentPhotoShielded" src="data: image/jpeg;base64,*?(.+?)">',flags=re.S)
hexed     = userp.search(request.text).group().replace('">','')
hexed     = hexed.replace('<img id="studentPhotoShielded" src="data: image/jpeg;base64,','')

name_reg  = re.compile(r'fullName: "*?(.+?)"',flags=re.S)
name      = name_reg.search(request.text).group()
name      = name.replace('fullName: "','').replace('"','')

usr_info.append(name.split(' '))

uhex(hexed,'avatar.jpeg')

match   = re.compile(r'<(.+?)>')
headers = match.findall(raw_table)

headers += ['<','>','/','\n']

for header in headers:
    raw_table = raw_table.replace(header,'')

raw_table = raw_table.split('\t')
raw_table = [item.strip(' ') for item in raw_table if item][1:-1]
raw_table = [item for item in raw_table if not '=' in item]

dump('|')
