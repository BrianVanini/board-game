from flask import Flask
from flask_restful import Resource, Api
from api.player import *
from db.init_db import insert_test_data

app = Flask(__name__)
api = Api(app)

api.add_resource(Player, '/player')

if __name__ == '__main__':
    insert_test_data()
    app.run(debug=True)
