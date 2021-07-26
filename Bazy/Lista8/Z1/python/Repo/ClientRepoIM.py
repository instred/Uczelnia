import sys
from Interface import IClientRepo

sys.path.append("~/bd/turtle_pack/src/interfaces")


class ClientRepoIM(IClientRepo):

    def __init__(self):
        self.list = []

    def insert(self, client):
        self.list.append(client)

    def delete(self, id):
        del self.list[id]

    def find(self, id):
        return self.list[id]

    def findAll(self):
        return self.list