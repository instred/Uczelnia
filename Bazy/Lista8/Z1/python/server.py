from flask import Flask, jsonify
import prodQueries
from connection import get_conn

app = Flask(__name__)
connection = get_conn()


@app.route('/get_all', methods=['GET'])
def get_all():
    products = prodQueries.get_stock(connection)
    response = jsonify(products)
    response.headers.add('Access-Control-Allow-Origin', '*')

    return response


if __name__ == '__main__':
    print('Starting Flask... ')
    app.run(port=5000)
