import os
from os.path import join, basename
import shutil
import subprocess
import argparse


class DefaultList(list):
    def __copy__(self):
        return []

def unpack(args): # Workaround python 3.4
    return ' '.join(args)

def main():
    parser = argparse.ArgumentParser(description='CSharp protobuf generator')
    parser.add_argument('--protoc', action='append', default=DefaultList(['protoc']))
    parser.add_argument('--grpc_csharp_plugin', default='grpc_csharp_plugin')
    parser.add_argument('--output', default='GeneratedProtos')
    parser.add_argument('--targets', action='append', default=[], help='List of projects containing protobufs')
    args = parser.parse_args()

    protos = []
    includes = list(map(lambda x: '-I' + join(x, 'include'), args.targets))
    if os.path.exists(args.output):
        shutil.rmtree(args.output)
    os.mkdir(args.output)
    for target in args.targets:
        root = join(target, 'include')
        for dirpath, dirnames, filenames in os.walk(root):
            dst = join(args.output, '\\'.join(dirpath.split('\\')[2:]))
            for f in filenames:
                if f.endswith('.proto'):
                    os.makedirs(dst, exist_ok=True)
                    cmd = [
                        unpack(args.protoc),
                        '--plugin=protoc-gen-grpc=' + args.grpc_csharp_plugin
                    ] + includes + [
                        '--csharp_out=' + dst,
                        '--grpc_out=' + dst,
                        join(dirpath, f)
                    ]
                    subprocess.check_call(cmd)
    for dirpath, dirnames, filenames in os.walk(args.output):
        for fname in filenames:
            fpath = join(dirpath, fname)
            with open(fpath, 'r') as f:
                data = f.read()
            # patch here
            with open(fpath, 'w') as f:
                f.write(data)


if __name__ == '__main__':
    main()