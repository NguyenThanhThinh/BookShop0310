# BookShop0310
Book shop service use asp net core

| Http Method      | Endpoint | Description |
| :---        |    :----:   |          ---: |
| GET     | /api/authors/{id}| Gets author with id, first name, last name and a list of all his/her book titles.  |
| POST     | /api/authors| Creates a new author with first name and last name.  |
| GET     | /api/authors/{id}/books| Gets books from author by id. returns all data about the book + category names.  |
