from flask_restful import Resource
from db.db_utils import *
from db.init_db import *

class Player(Resource):
    def get(self):
        return exec_get_all('SELECT * FROM PLAYER')
    
