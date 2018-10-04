# BookShop0310
Book shop service use asp net core

## Define the following endpoints in your service project
| Http Method | Endpoint | Description |
| :---        |    :----   |          :--- |
| GET     | /api/authors/{id}| Gets author with id, first name, last name and a list of all his/her book titles.  |
| POST     | /api/authors| Creates a new author with first name and last name.  |
| GET     | /api/authors/{id}/books| Gets books from author by id. returns all data about the book + category names.  |
| GET     | /api/books/{id}| Gets data about a book by id. Returns all data about the book + category names + author name and id.  |
| GET     | /api/books?search={word}| Gets top 10 books which contain the given substring, sorted by title (ascending). Returns only the title and id of the books.  |
| PUT     | /api/books/{id}| Edits the book. Receives book title, description, price, copies, edition, age restriction, release date and author id.  |
| DELETE     | /api/books/{id}| Delete a book  |

