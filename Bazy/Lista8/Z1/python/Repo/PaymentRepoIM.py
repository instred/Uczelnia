import sys
from python.Repo.Interface import IPaymentRepo

sys.path.append("~/bd/turtle_pack/src/interfaces")


class PaymentRepoIM(IPaymentRepo):

    def __init__(self):
        self.list = []

    def insert(self, pay):
        self.list.append(pay)

    def delete(self, id):
        del self.list[id]

    def find(self, id):
        return self.list[id]

    def findAll(self):
        return self.list