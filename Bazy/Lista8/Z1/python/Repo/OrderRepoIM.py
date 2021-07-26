import sys
from Interface import IOrderRepo

sys.path.append("~/bd/turtle_pack/src/interfaces")


class OrderRepoIM(IOrderRepo):

    def __init__(self):
        self.list = []

    def insert(self, order):
        self.list.append(order)

    def delete(self, id):
        del self.list[id]

    def find(self, id):
        return self.list[id]

    def findAll(self):
        return self.list
