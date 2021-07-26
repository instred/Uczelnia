import sys
from Interface import IAddrRepo
sys.path.append("~/bd/turtle_pack/src/interfaces")


class AddrRepoIM(IAddrRepo):

    def __init__(self):
        self.list=[]

    def insert(self, addr):
        self.list.append(addr)

    def delete(self,id):
        del self.list[id]

    def find(self,id):
        return self.list[id]
    
    def findAll(self):
        return self.list