from connection import get_conn


def get_stock(connection):
    cursor = connection.cursor()
    query = 'SELECT idbucik, marka, model, kolorystyka, cenaPLN, cenaGBP, link FROM buciki'
    cursor.execute(query)
    stock = []
    for (idbucik, marka, model, kolorystyka, cenaPLN, link) in cursor:
        stock.append(
            {
                'idbucik': idbucik,
                'marka': marka,
                'model': model,
                'kolorystyka': kolorystyka,
                'cenaPLN': cenaPLN,
                'link': link
            }
        )
        print(marka, model, kolorystyka, cenaPLN, link)

    return stock


def insert_prod(connection, product):
    cursor = connection.cursor()
    query = ('INSERT INTO buciki.buciki(marka, model, kolorystyka, rozmiar, SKU, cenaPLN) VALUES (%s, %s, %s, %s, %s, %s)')
    data = (product['marka'], product['model'], product['kolorystyka'], product['rozmiar'],
            product['SKU'], product['cenaPLN'], )
    cursor.execute(query, data)
    connection.commit()
    return cursor.lastrowid


def delete_prod(connection, idbut):
    cursor = connection.cursor()
    query = ('DELETE FROM buciki WHERE idbuciki=' + str(idbut))
    cursor.execute(query)
    connection.commit()


if __name__ == '__main__':
    ctx = get_conn()
    print(delete_prod(ctx, 2))
