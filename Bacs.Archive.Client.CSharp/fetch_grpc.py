import os, urllib.request, shutil

install_dir = 'packages/Grpc.Tools'
temp_dir = install_dir+"/tmp"
temp_archive = temp_dir+'/tmp.zip'
temp_tools_dir = temp_dir+'/tools'
tools_dir = install_dir+'/tools'
url = 'https://www.nuget.org/api/v2/package/Grpc.Tools/'

if not os.path.exists(temp_dir):
    os.makedirs(temp_dir)

urllib.request.urlretrieve(url, temp_archive)

import zipfile
with zipfile.ZipFile(temp_archive,"r") as zip_ref:
    zip_ref.extractall(temp_dir)

if os.path.exists(tools_dir):
    shutil.rmtree(tools_dir)
    
shutil.copytree(temp_tools_dir, tools_dir)
shutil.rmtree(temp_dir)