import sys
from python.Repo.Interface import IProductRepo

sys.path.append("~/bd/turtle_pack/src/interfaces")


class ProductRepoIM(IProductRepo):

    def __init__(self):
        self.list = []

    def insert(self, prod):
        self.list.append(prod)

    def delete(self, id):
        del self.list[id]

    def find(self, id):
        return self.list[id]

    def findAll(self):
        return self.list