import mysql.connector

__conn = None


def get_conn():
    global __conn
    if __conn is None:
        __conn = mysql.connector.connect(user='root', password='', host='127.0.0.1', database='buciki')
    return __conn
