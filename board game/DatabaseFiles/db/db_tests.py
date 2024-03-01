from db_utils import *
from unittest import *

def initializeDB():
    exec_sql_file('boardgame.sql')

def test_get_position(self):
    initializeDB()
    result = exec_get_all("SELECT * FROM position")
    self.assertEqual(3, result, "Incorrect number of rows in position table")




    
