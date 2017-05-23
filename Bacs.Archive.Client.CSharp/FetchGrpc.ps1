$install_dir = 'packages/Grpc.Tools'
$temp_dir = 'tmp'
$temp_archive_name = 'tmp'
$tools_dir = 'tools'
$url = 'https://www.nuget.org/api/v2/package/Grpc.Tools/'

if(!(Test-Path "$($install_dir)/$($temp_dir)")) {
	mkdir -p "$($install_dir)/$($temp_dir)"
}

Set-Location "$($install_dir)"

if(Test-Path $tools_dir) {
	Remove-Item $tools_dir -Recurse -Force
}
Set-Location "$($temp_dir)"


Write-Output "Downloading..."
Invoke-WebRequest -Uri $url -OutFile "$($temp_archive_name).zip"


Write-Output "Extracting..."
Expand-Archive "$($temp_archive_name).zip"
Set-Location ..
Copy-Item "$($temp_dir)/$($temp_archive_name)/$($tools_dir)" . -Recurse

Write-Output "Cleaning up..."
Remove-Item $temp_dir -Recurse -Force
Set-Location ../..

Write-Output "Done!"
