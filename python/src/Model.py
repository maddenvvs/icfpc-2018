from itertools import product
import math


class Model():
    def __init__(self, R, bytes_arr):
        self.R = R
        self.bytes = bytes_arr

    def is_point_full(self, point):
        x, y, z = point
        return self.is_coords_full(x, y, z)

    def is_coords_full(self, x, y, z):
        R = self.R
        bytes_pos, bit_pos = divmod(x*R*R+y*R+z, 8)
        mask = 1 << bit_pos
        return (self.bytes[bytes_pos] & mask) >> bit_pos

    def resolution(self):
        return self.R

    def full_count(self):
        R = self.R
        count = 0
        for x, y, z in product(range(R), range(R), range(R)):
            if self.is_coords_full(x, y, z):
                count += 1
        return count

    @staticmethod
    def from_bytes(bytes):
        R = bytes[0]
        return Model(R, bytes[1:])

    @staticmethod
    def empty(R):
        arr_size = math.ceil(pow(R, 3) / 8)
        return Model(R, [0 for _ in range(arr_size)])
