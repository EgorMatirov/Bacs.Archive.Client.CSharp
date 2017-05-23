cd /d %~dp0 
python cs-protogen\generate.py ^
    --protoc="../packages/Grpc.Tools/tools/windows_x64/protoc.exe" ^
    --grpc_csharp_plugin="../packages/Grpc.Tools/tools/windows_x64/grpc_csharp_plugin.exe" ^
    --output="GeneratedProtos" ^
    --targets=protos/google_protobuf ^
    --targets=protos/common ^
    --targets=protos/problem ^
    --targets=protos/archive ^
	--targets=protos/problem_single
