from Model import *


def bytes_from_file(filename, chunksize=8192):
    with open(filename, "rb") as f:
        while True:
            chunk = f.read(chunksize)
            if chunk:
                for b in chunk:
                    yield b
            else:
                break


def main():
    model_bytes = [b for b in bytes_from_file('LA186_tgt.mdl')]
    model = Model.from_bytes(model_bytes)

    print(model.resolution())
    print(model.full_count())


if __name__ == '__main__':
    main()
