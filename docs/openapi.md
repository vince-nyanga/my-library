---
title: My Library API v1
language_tabs:
  - shell: Shell
  - http: HTTP
  - javascript: JavaScript
  - ruby: Ruby
  - python: Python
  - php: PHP
  - java: Java
  - go: Go
toc_footers: []
includes: []
search: true
highlight_theme: darkula
headingLevel: 2

---

<!-- Generator: Widdershins v4.0.1 -->

<h1 id="my-library-api">My Library API v1</h1>

> Scroll down for code samples, example requests and responses. Select a language for code samples from the tabs above or the mobile navigation menu.

REST API for My Library

# Authentication

- oAuth2 authentication. 

    - Flow: implicit
    - Authorization URL = [https://vinarah.eu.auth0.com/authorize?audience=api://my-library.co.za](https://vinarah.eu.auth0.com/authorize?audience=api://my-library.co.za)

|Scope|Scope Description|
|---|---|
|openid|Open Id|

<h1 id="my-library-api-books">Books</h1>

## AddBookAsync

<a id="opIdAddBookAsync"></a>

> Code samples

```shell
# You can also use wget
curl -X POST /api/books \
  -H 'Content-Type: application/json' \
  -H 'Accept: text/plain' \
  -H 'Authorization: Bearer {access-token}'

```

```http
POST /api/books HTTP/1.1

Content-Type: application/json
Accept: text/plain

```

```javascript
const inputBody = '{
  "id": "EABAA778-F8F2-4491-B80D-F9B5B15A0237",
  "title": "The Green Moon by John Doe",
  "numberOfCopies": 18
}';
const headers = {
  'Content-Type':'application/json',
  'Accept':'text/plain',
  'Authorization':'Bearer {access-token}'
};

fetch('/api/books',
{
  method: 'POST',
  body: inputBody,
  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```ruby
require 'rest-client'
require 'json'

headers = {
  'Content-Type' => 'application/json',
  'Accept' => 'text/plain',
  'Authorization' => 'Bearer {access-token}'
}

result = RestClient.post '/api/books',
  params: {
  }, headers: headers

p JSON.parse(result)

```

```python
import requests
headers = {
  'Content-Type': 'application/json',
  'Accept': 'text/plain',
  'Authorization': 'Bearer {access-token}'
}

r = requests.post('/api/books', headers = headers)

print(r.json())

```

```php
<?php

require 'vendor/autoload.php';

$headers = array(
    'Content-Type' => 'application/json',
    'Accept' => 'text/plain',
    'Authorization' => 'Bearer {access-token}',
);

$client = new \GuzzleHttp\Client();

// Define array of request body.
$request_body = array();

try {
    $response = $client->request('POST','/api/books', array(
        'headers' => $headers,
        'json' => $request_body,
       )
    );
    print_r($response->getBody()->getContents());
 }
 catch (\GuzzleHttp\Exception\BadResponseException $e) {
    // handle exception or api errors.
    print_r($e->getMessage());
 }

 // ...

```

```java
URL obj = new URL("/api/books");
HttpURLConnection con = (HttpURLConnection) obj.openConnection();
con.setRequestMethod("POST");
int responseCode = con.getResponseCode();
BufferedReader in = new BufferedReader(
    new InputStreamReader(con.getInputStream()));
String inputLine;
StringBuffer response = new StringBuffer();
while ((inputLine = in.readLine()) != null) {
    response.append(inputLine);
}
in.close();
System.out.println(response.toString());

```

```go
package main

import (
       "bytes"
       "net/http"
)

func main() {

    headers := map[string][]string{
        "Content-Type": []string{"application/json"},
        "Accept": []string{"text/plain"},
        "Authorization": []string{"Bearer {access-token}"},
    }

    data := bytes.NewBuffer([]byte{jsonReq})
    req, err := http.NewRequest("POST", "/api/books", data)
    req.Header = headers

    client := &http.Client{}
    resp, err := client.Do(req)
    // ...
}

```

`POST /api/books`

*Adds a new book to the library.*

> Body parameter

```json
{
  "id": "EABAA778-F8F2-4491-B80D-F9B5B15A0237",
  "title": "The Green Moon by John Doe",
  "numberOfCopies": 18
}
```

<h3 id="addbookasync-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[AddBookRequest](#schemaaddbookrequest)|false|The request containing new book details.|

> Example responses

> 401 Response

```
{"type":"string","title":"string","status":0,"detail":"string","instance":"string","property1":null,"property2":null}
```

```json
{
  "type": "string",
  "title": "string",
  "status": 0,
  "detail": "string",
  "instance": "string",
  "property1": null,
  "property2": null
}
```

<h3 id="addbookasync-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|None|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|[ProblemDetails](#schemaproblemdetails)|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Forbidden|[ProblemDetails](#schemaproblemdetails)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
oauth2 ( Scopes: openid )
</aside>

## GetAllBooksAsync

<a id="opIdGetAllBooksAsync"></a>

> Code samples

```shell
# You can also use wget
curl -X GET /api/books \
  -H 'Accept: text/plain' \
  -H 'Authorization: Bearer {access-token}'

```

```http
GET /api/books HTTP/1.1

Accept: text/plain

```

```javascript

const headers = {
  'Accept':'text/plain',
  'Authorization':'Bearer {access-token}'
};

fetch('/api/books',
{
  method: 'GET',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```ruby
require 'rest-client'
require 'json'

headers = {
  'Accept' => 'text/plain',
  'Authorization' => 'Bearer {access-token}'
}

result = RestClient.get '/api/books',
  params: {
  }, headers: headers

p JSON.parse(result)

```

```python
import requests
headers = {
  'Accept': 'text/plain',
  'Authorization': 'Bearer {access-token}'
}

r = requests.get('/api/books', headers = headers)

print(r.json())

```

```php
<?php

require 'vendor/autoload.php';

$headers = array(
    'Accept' => 'text/plain',
    'Authorization' => 'Bearer {access-token}',
);

$client = new \GuzzleHttp\Client();

// Define array of request body.
$request_body = array();

try {
    $response = $client->request('GET','/api/books', array(
        'headers' => $headers,
        'json' => $request_body,
       )
    );
    print_r($response->getBody()->getContents());
 }
 catch (\GuzzleHttp\Exception\BadResponseException $e) {
    // handle exception or api errors.
    print_r($e->getMessage());
 }

 // ...

```

```java
URL obj = new URL("/api/books");
HttpURLConnection con = (HttpURLConnection) obj.openConnection();
con.setRequestMethod("GET");
int responseCode = con.getResponseCode();
BufferedReader in = new BufferedReader(
    new InputStreamReader(con.getInputStream()));
String inputLine;
StringBuffer response = new StringBuffer();
while ((inputLine = in.readLine()) != null) {
    response.append(inputLine);
}
in.close();
System.out.println(response.toString());

```

```go
package main

import (
       "bytes"
       "net/http"
)

func main() {

    headers := map[string][]string{
        "Accept": []string{"text/plain"},
        "Authorization": []string{"Bearer {access-token}"},
    }

    data := bytes.NewBuffer([]byte{jsonReq})
    req, err := http.NewRequest("GET", "/api/books", data)
    req.Header = headers

    client := &http.Client{}
    resp, err := client.Do(req)
    // ...
}

```

`GET /api/books`

*Gets all books in the library.*

> Example responses

> 200 Response

```
[{"id":"EABAA778-F8F2-4491-B80D-F9B5B15A0237","title":"The Green Moon by John Doe","availableCopies":17,"nextAvailableCopyDate":"2023-12-25"}]
```

```json
[
  {
    "id": "EABAA778-F8F2-4491-B80D-F9B5B15A0237",
    "title": "The Green Moon by John Doe",
    "availableCopies": 17,
    "nextAvailableCopyDate": "2023-12-25"
  }
]
```

<h3 id="getallbooksasync-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|Inline|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|[ProblemDetails](#schemaproblemdetails)|

<h3 id="getallbooksasync-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[BookResponse](#schemabookresponse)]|false|none|none|
|» id|string(uuid)|true|none|The book id.|
|» title|string|true|none|The book title.|
|» availableCopies|integer(int32)|false|none|Total copies available in the library at the moment.|
|» nextAvailableCopyDate|string(date)¦null|false|none|The closest date when a borrowed copy will be returned.|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
oauth2 ( Scopes: openid )
</aside>

## BorrowBookAsync

<a id="opIdBorrowBookAsync"></a>

> Code samples

```shell
# You can also use wget
curl -X POST /api/books/{id}/borrow \
  -H 'Content-Type: application/json' \
  -H 'Accept: text/plain' \
  -H 'Authorization: Bearer {access-token}'

```

```http
POST /api/books/{id}/borrow HTTP/1.1

Content-Type: application/json
Accept: text/plain

```

```javascript
const inputBody = '{
  "returnDate": "2023-12-25"
}';
const headers = {
  'Content-Type':'application/json',
  'Accept':'text/plain',
  'Authorization':'Bearer {access-token}'
};

fetch('/api/books/{id}/borrow',
{
  method: 'POST',
  body: inputBody,
  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```ruby
require 'rest-client'
require 'json'

headers = {
  'Content-Type' => 'application/json',
  'Accept' => 'text/plain',
  'Authorization' => 'Bearer {access-token}'
}

result = RestClient.post '/api/books/{id}/borrow',
  params: {
  }, headers: headers

p JSON.parse(result)

```

```python
import requests
headers = {
  'Content-Type': 'application/json',
  'Accept': 'text/plain',
  'Authorization': 'Bearer {access-token}'
}

r = requests.post('/api/books/{id}/borrow', headers = headers)

print(r.json())

```

```php
<?php

require 'vendor/autoload.php';

$headers = array(
    'Content-Type' => 'application/json',
    'Accept' => 'text/plain',
    'Authorization' => 'Bearer {access-token}',
);

$client = new \GuzzleHttp\Client();

// Define array of request body.
$request_body = array();

try {
    $response = $client->request('POST','/api/books/{id}/borrow', array(
        'headers' => $headers,
        'json' => $request_body,
       )
    );
    print_r($response->getBody()->getContents());
 }
 catch (\GuzzleHttp\Exception\BadResponseException $e) {
    // handle exception or api errors.
    print_r($e->getMessage());
 }

 // ...

```

```java
URL obj = new URL("/api/books/{id}/borrow");
HttpURLConnection con = (HttpURLConnection) obj.openConnection();
con.setRequestMethod("POST");
int responseCode = con.getResponseCode();
BufferedReader in = new BufferedReader(
    new InputStreamReader(con.getInputStream()));
String inputLine;
StringBuffer response = new StringBuffer();
while ((inputLine = in.readLine()) != null) {
    response.append(inputLine);
}
in.close();
System.out.println(response.toString());

```

```go
package main

import (
       "bytes"
       "net/http"
)

func main() {

    headers := map[string][]string{
        "Content-Type": []string{"application/json"},
        "Accept": []string{"text/plain"},
        "Authorization": []string{"Bearer {access-token}"},
    }

    data := bytes.NewBuffer([]byte{jsonReq})
    req, err := http.NewRequest("POST", "/api/books/{id}/borrow", data)
    req.Header = headers

    client := &http.Client{}
    resp, err := client.Do(req)
    // ...
}

```

`POST /api/books/{id}/borrow`

*Borrows a book for the logged in user.*

> Body parameter

```json
{
  "returnDate": "2023-12-25"
}
```

<h3 id="borrowbookasync-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|string(uuid)|true|The book ID|
|body|body|[BorrowBookRequest](#schemaborrowbookrequest)|false|The request.|

> Example responses

> 400 Response

```
{"type":"string","title":"string","status":0,"detail":"string","instance":"string","property1":null,"property2":null}
```

```json
{
  "type": "string",
  "title": "string",
  "status": 0,
  "detail": "string",
  "instance": "string",
  "property1": null,
  "property2": null
}
```

<h3 id="borrowbookasync-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|None|
|400|[Bad Request](https://tools.ietf.org/html/rfc7231#section-6.5.1)|Bad Request|[ProblemDetails](#schemaproblemdetails)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|[ProblemDetails](#schemaproblemdetails)|
|409|[Conflict](https://tools.ietf.org/html/rfc7231#section-6.5.8)|Conflict|[ProblemDetails](#schemaproblemdetails)|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[ProblemDetails](#schemaproblemdetails)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
oauth2 ( Scopes: openid )
</aside>

## CancelReservationAsync

<a id="opIdCancelReservationAsync"></a>

> Code samples

```shell
# You can also use wget
curl -X POST /api/books/{id}/cancel-reservation \
  -H 'Accept: text/plain' \
  -H 'Authorization: Bearer {access-token}'

```

```http
POST /api/books/{id}/cancel-reservation HTTP/1.1

Accept: text/plain

```

```javascript

const headers = {
  'Accept':'text/plain',
  'Authorization':'Bearer {access-token}'
};

fetch('/api/books/{id}/cancel-reservation',
{
  method: 'POST',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```ruby
require 'rest-client'
require 'json'

headers = {
  'Accept' => 'text/plain',
  'Authorization' => 'Bearer {access-token}'
}

result = RestClient.post '/api/books/{id}/cancel-reservation',
  params: {
  }, headers: headers

p JSON.parse(result)

```

```python
import requests
headers = {
  'Accept': 'text/plain',
  'Authorization': 'Bearer {access-token}'
}

r = requests.post('/api/books/{id}/cancel-reservation', headers = headers)

print(r.json())

```

```php
<?php

require 'vendor/autoload.php';

$headers = array(
    'Accept' => 'text/plain',
    'Authorization' => 'Bearer {access-token}',
);

$client = new \GuzzleHttp\Client();

// Define array of request body.
$request_body = array();

try {
    $response = $client->request('POST','/api/books/{id}/cancel-reservation', array(
        'headers' => $headers,
        'json' => $request_body,
       )
    );
    print_r($response->getBody()->getContents());
 }
 catch (\GuzzleHttp\Exception\BadResponseException $e) {
    // handle exception or api errors.
    print_r($e->getMessage());
 }

 // ...

```

```java
URL obj = new URL("/api/books/{id}/cancel-reservation");
HttpURLConnection con = (HttpURLConnection) obj.openConnection();
con.setRequestMethod("POST");
int responseCode = con.getResponseCode();
BufferedReader in = new BufferedReader(
    new InputStreamReader(con.getInputStream()));
String inputLine;
StringBuffer response = new StringBuffer();
while ((inputLine = in.readLine()) != null) {
    response.append(inputLine);
}
in.close();
System.out.println(response.toString());

```

```go
package main

import (
       "bytes"
       "net/http"
)

func main() {

    headers := map[string][]string{
        "Accept": []string{"text/plain"},
        "Authorization": []string{"Bearer {access-token}"},
    }

    data := bytes.NewBuffer([]byte{jsonReq})
    req, err := http.NewRequest("POST", "/api/books/{id}/cancel-reservation", data)
    req.Header = headers

    client := &http.Client{}
    resp, err := client.Do(req)
    // ...
}

```

`POST /api/books/{id}/cancel-reservation`

*Cancels the logged in user's reservation.*

<h3 id="cancelreservationasync-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|string(uuid)|true|The book ID|

> Example responses

> 401 Response

```
{"type":"string","title":"string","status":0,"detail":"string","instance":"string","property1":null,"property2":null}
```

```json
{
  "type": "string",
  "title": "string",
  "status": 0,
  "detail": "string",
  "instance": "string",
  "property1": null,
  "property2": null
}
```

<h3 id="cancelreservationasync-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|None|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|[ProblemDetails](#schemaproblemdetails)|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Not Found|[ProblemDetails](#schemaproblemdetails)|
|409|[Conflict](https://tools.ietf.org/html/rfc7231#section-6.5.8)|Conflict|[ProblemDetails](#schemaproblemdetails)|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[ProblemDetails](#schemaproblemdetails)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
oauth2 ( Scopes: openid )
</aside>

## GetOwnBorrowedBooksAsync

<a id="opIdGetOwnBorrowedBooksAsync"></a>

> Code samples

```shell
# You can also use wget
curl -X GET /api/books/own/borrowed \
  -H 'Accept: text/plain' \
  -H 'Authorization: Bearer {access-token}'

```

```http
GET /api/books/own/borrowed HTTP/1.1

Accept: text/plain

```

```javascript

const headers = {
  'Accept':'text/plain',
  'Authorization':'Bearer {access-token}'
};

fetch('/api/books/own/borrowed',
{
  method: 'GET',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```ruby
require 'rest-client'
require 'json'

headers = {
  'Accept' => 'text/plain',
  'Authorization' => 'Bearer {access-token}'
}

result = RestClient.get '/api/books/own/borrowed',
  params: {
  }, headers: headers

p JSON.parse(result)

```

```python
import requests
headers = {
  'Accept': 'text/plain',
  'Authorization': 'Bearer {access-token}'
}

r = requests.get('/api/books/own/borrowed', headers = headers)

print(r.json())

```

```php
<?php

require 'vendor/autoload.php';

$headers = array(
    'Accept' => 'text/plain',
    'Authorization' => 'Bearer {access-token}',
);

$client = new \GuzzleHttp\Client();

// Define array of request body.
$request_body = array();

try {
    $response = $client->request('GET','/api/books/own/borrowed', array(
        'headers' => $headers,
        'json' => $request_body,
       )
    );
    print_r($response->getBody()->getContents());
 }
 catch (\GuzzleHttp\Exception\BadResponseException $e) {
    // handle exception or api errors.
    print_r($e->getMessage());
 }

 // ...

```

```java
URL obj = new URL("/api/books/own/borrowed");
HttpURLConnection con = (HttpURLConnection) obj.openConnection();
con.setRequestMethod("GET");
int responseCode = con.getResponseCode();
BufferedReader in = new BufferedReader(
    new InputStreamReader(con.getInputStream()));
String inputLine;
StringBuffer response = new StringBuffer();
while ((inputLine = in.readLine()) != null) {
    response.append(inputLine);
}
in.close();
System.out.println(response.toString());

```

```go
package main

import (
       "bytes"
       "net/http"
)

func main() {

    headers := map[string][]string{
        "Accept": []string{"text/plain"},
        "Authorization": []string{"Bearer {access-token}"},
    }

    data := bytes.NewBuffer([]byte{jsonReq})
    req, err := http.NewRequest("GET", "/api/books/own/borrowed", data)
    req.Header = headers

    client := &http.Client{}
    resp, err := client.Do(req)
    // ...
}

```

`GET /api/books/own/borrowed`

*Gets a list of the logged in user's borrowed books*

> Example responses

> 200 Response

```
[{"id":"EABAA778-F8F2-4491-B80D-F9B5B15A0237","title":"The Green Moon by John Doe","dueDate":"2023-12-25"}]
```

```json
[
  {
    "id": "EABAA778-F8F2-4491-B80D-F9B5B15A0237",
    "title": "The Green Moon by John Doe",
    "dueDate": "2023-12-25"
  }
]
```

<h3 id="getownborrowedbooksasync-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|Inline|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|[ProblemDetails](#schemaproblemdetails)|

<h3 id="getownborrowedbooksasync-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[BorrowedBookResponse](#schemaborrowedbookresponse)]|false|none|none|
|» id|string(uuid)|false|none|The book id.|
|» title|string|true|none|The book title.|
|» dueDate|string(date)|false|none|The date by which the book should be returned.|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
oauth2 ( Scopes: openid )
</aside>

## GetOwnReservedBooksAsync

<a id="opIdGetOwnReservedBooksAsync"></a>

> Code samples

```shell
# You can also use wget
curl -X GET /api/books/own/reserved \
  -H 'Accept: text/plain' \
  -H 'Authorization: Bearer {access-token}'

```

```http
GET /api/books/own/reserved HTTP/1.1

Accept: text/plain

```

```javascript

const headers = {
  'Accept':'text/plain',
  'Authorization':'Bearer {access-token}'
};

fetch('/api/books/own/reserved',
{
  method: 'GET',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```ruby
require 'rest-client'
require 'json'

headers = {
  'Accept' => 'text/plain',
  'Authorization' => 'Bearer {access-token}'
}

result = RestClient.get '/api/books/own/reserved',
  params: {
  }, headers: headers

p JSON.parse(result)

```

```python
import requests
headers = {
  'Accept': 'text/plain',
  'Authorization': 'Bearer {access-token}'
}

r = requests.get('/api/books/own/reserved', headers = headers)

print(r.json())

```

```php
<?php

require 'vendor/autoload.php';

$headers = array(
    'Accept' => 'text/plain',
    'Authorization' => 'Bearer {access-token}',
);

$client = new \GuzzleHttp\Client();

// Define array of request body.
$request_body = array();

try {
    $response = $client->request('GET','/api/books/own/reserved', array(
        'headers' => $headers,
        'json' => $request_body,
       )
    );
    print_r($response->getBody()->getContents());
 }
 catch (\GuzzleHttp\Exception\BadResponseException $e) {
    // handle exception or api errors.
    print_r($e->getMessage());
 }

 // ...

```

```java
URL obj = new URL("/api/books/own/reserved");
HttpURLConnection con = (HttpURLConnection) obj.openConnection();
con.setRequestMethod("GET");
int responseCode = con.getResponseCode();
BufferedReader in = new BufferedReader(
    new InputStreamReader(con.getInputStream()));
String inputLine;
StringBuffer response = new StringBuffer();
while ((inputLine = in.readLine()) != null) {
    response.append(inputLine);
}
in.close();
System.out.println(response.toString());

```

```go
package main

import (
       "bytes"
       "net/http"
)

func main() {

    headers := map[string][]string{
        "Accept": []string{"text/plain"},
        "Authorization": []string{"Bearer {access-token}"},
    }

    data := bytes.NewBuffer([]byte{jsonReq})
    req, err := http.NewRequest("GET", "/api/books/own/reserved", data)
    req.Header = headers

    client := &http.Client{}
    resp, err := client.Do(req)
    // ...
}

```

`GET /api/books/own/reserved`

*Gets a list of the logged in user's reserved books.*

> Example responses

> 200 Response

```
[{"id":"EABAA778-F8F2-4491-B80D-F9B5B15A0237","title":"The Green Moon by John Doe","reservationExpiryDate":"2023-12-25T06:00:00.000Z"}]
```

```json
[
  {
    "id": "EABAA778-F8F2-4491-B80D-F9B5B15A0237",
    "title": "The Green Moon by John Doe",
    "reservationExpiryDate": "2023-12-25T06:00:00.000Z"
  }
]
```

<h3 id="getownreservedbooksasync-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|Inline|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|[ProblemDetails](#schemaproblemdetails)|

<h3 id="getownreservedbooksasync-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[ReservedBookResponse](#schemareservedbookresponse)]|false|none|none|
|» id|string(uuid)|false|none|The book id.|
|» title|string|true|none|The book title.|
|» reservationExpiryDate|string(date-time)|false|none|The date and time on which the reservation will expire.|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
oauth2 ( Scopes: openid )
</aside>

## ReserveBookAsync

<a id="opIdReserveBookAsync"></a>

> Code samples

```shell
# You can also use wget
curl -X POST /api/books/{id}/reserve \
  -H 'Accept: text/plain' \
  -H 'Authorization: Bearer {access-token}'

```

```http
POST /api/books/{id}/reserve HTTP/1.1

Accept: text/plain

```

```javascript

const headers = {
  'Accept':'text/plain',
  'Authorization':'Bearer {access-token}'
};

fetch('/api/books/{id}/reserve',
{
  method: 'POST',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```ruby
require 'rest-client'
require 'json'

headers = {
  'Accept' => 'text/plain',
  'Authorization' => 'Bearer {access-token}'
}

result = RestClient.post '/api/books/{id}/reserve',
  params: {
  }, headers: headers

p JSON.parse(result)

```

```python
import requests
headers = {
  'Accept': 'text/plain',
  'Authorization': 'Bearer {access-token}'
}

r = requests.post('/api/books/{id}/reserve', headers = headers)

print(r.json())

```

```php
<?php

require 'vendor/autoload.php';

$headers = array(
    'Accept' => 'text/plain',
    'Authorization' => 'Bearer {access-token}',
);

$client = new \GuzzleHttp\Client();

// Define array of request body.
$request_body = array();

try {
    $response = $client->request('POST','/api/books/{id}/reserve', array(
        'headers' => $headers,
        'json' => $request_body,
       )
    );
    print_r($response->getBody()->getContents());
 }
 catch (\GuzzleHttp\Exception\BadResponseException $e) {
    // handle exception or api errors.
    print_r($e->getMessage());
 }

 // ...

```

```java
URL obj = new URL("/api/books/{id}/reserve");
HttpURLConnection con = (HttpURLConnection) obj.openConnection();
con.setRequestMethod("POST");
int responseCode = con.getResponseCode();
BufferedReader in = new BufferedReader(
    new InputStreamReader(con.getInputStream()));
String inputLine;
StringBuffer response = new StringBuffer();
while ((inputLine = in.readLine()) != null) {
    response.append(inputLine);
}
in.close();
System.out.println(response.toString());

```

```go
package main

import (
       "bytes"
       "net/http"
)

func main() {

    headers := map[string][]string{
        "Accept": []string{"text/plain"},
        "Authorization": []string{"Bearer {access-token}"},
    }

    data := bytes.NewBuffer([]byte{jsonReq})
    req, err := http.NewRequest("POST", "/api/books/{id}/reserve", data)
    req.Header = headers

    client := &http.Client{}
    resp, err := client.Do(req)
    // ...
}

```

`POST /api/books/{id}/reserve`

*Reserves a book for the logged in user.*

<h3 id="reservebookasync-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|string(uuid)|true|The book ID|

> Example responses

> 401 Response

```
{"type":"string","title":"string","status":0,"detail":"string","instance":"string","property1":null,"property2":null}
```

```json
{
  "type": "string",
  "title": "string",
  "status": 0,
  "detail": "string",
  "instance": "string",
  "property1": null,
  "property2": null
}
```

<h3 id="reservebookasync-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|None|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|[ProblemDetails](#schemaproblemdetails)|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Not Found|[ProblemDetails](#schemaproblemdetails)|
|409|[Conflict](https://tools.ietf.org/html/rfc7231#section-6.5.8)|Conflict|[ProblemDetails](#schemaproblemdetails)|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[ProblemDetails](#schemaproblemdetails)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
oauth2 ( Scopes: openid )
</aside>

## ReturnBookAsync

<a id="opIdReturnBookAsync"></a>

> Code samples

```shell
# You can also use wget
curl -X POST /api/books/{id}/return \
  -H 'Accept: text/plain' \
  -H 'Authorization: Bearer {access-token}'

```

```http
POST /api/books/{id}/return HTTP/1.1

Accept: text/plain

```

```javascript

const headers = {
  'Accept':'text/plain',
  'Authorization':'Bearer {access-token}'
};

fetch('/api/books/{id}/return',
{
  method: 'POST',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```ruby
require 'rest-client'
require 'json'

headers = {
  'Accept' => 'text/plain',
  'Authorization' => 'Bearer {access-token}'
}

result = RestClient.post '/api/books/{id}/return',
  params: {
  }, headers: headers

p JSON.parse(result)

```

```python
import requests
headers = {
  'Accept': 'text/plain',
  'Authorization': 'Bearer {access-token}'
}

r = requests.post('/api/books/{id}/return', headers = headers)

print(r.json())

```

```php
<?php

require 'vendor/autoload.php';

$headers = array(
    'Accept' => 'text/plain',
    'Authorization' => 'Bearer {access-token}',
);

$client = new \GuzzleHttp\Client();

// Define array of request body.
$request_body = array();

try {
    $response = $client->request('POST','/api/books/{id}/return', array(
        'headers' => $headers,
        'json' => $request_body,
       )
    );
    print_r($response->getBody()->getContents());
 }
 catch (\GuzzleHttp\Exception\BadResponseException $e) {
    // handle exception or api errors.
    print_r($e->getMessage());
 }

 // ...

```

```java
URL obj = new URL("/api/books/{id}/return");
HttpURLConnection con = (HttpURLConnection) obj.openConnection();
con.setRequestMethod("POST");
int responseCode = con.getResponseCode();
BufferedReader in = new BufferedReader(
    new InputStreamReader(con.getInputStream()));
String inputLine;
StringBuffer response = new StringBuffer();
while ((inputLine = in.readLine()) != null) {
    response.append(inputLine);
}
in.close();
System.out.println(response.toString());

```

```go
package main

import (
       "bytes"
       "net/http"
)

func main() {

    headers := map[string][]string{
        "Accept": []string{"text/plain"},
        "Authorization": []string{"Bearer {access-token}"},
    }

    data := bytes.NewBuffer([]byte{jsonReq})
    req, err := http.NewRequest("POST", "/api/books/{id}/return", data)
    req.Header = headers

    client := &http.Client{}
    resp, err := client.Do(req)
    // ...
}

```

`POST /api/books/{id}/return`

*Returns a book borrowed by the logged in user to the library*

<h3 id="returnbookasync-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|string(uuid)|true|The book ID|

> Example responses

> 401 Response

```
{"type":"string","title":"string","status":0,"detail":"string","instance":"string","property1":null,"property2":null}
```

```json
{
  "type": "string",
  "title": "string",
  "status": 0,
  "detail": "string",
  "instance": "string",
  "property1": null,
  "property2": null
}
```

<h3 id="returnbookasync-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|None|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|[ProblemDetails](#schemaproblemdetails)|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Not Found|[ProblemDetails](#schemaproblemdetails)|
|409|[Conflict](https://tools.ietf.org/html/rfc7231#section-6.5.8)|Conflict|[ProblemDetails](#schemaproblemdetails)|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|Server Error|[ProblemDetails](#schemaproblemdetails)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
oauth2 ( Scopes: openid )
</aside>

## SearchBooksByTitleAsync

<a id="opIdSearchBooksByTitleAsync"></a>

> Code samples

```shell
# You can also use wget
curl -X POST /api/books/search \
  -H 'Content-Type: application/json' \
  -H 'Accept: text/plain' \
  -H 'Authorization: Bearer {access-token}'

```

```http
POST /api/books/search HTTP/1.1

Content-Type: application/json
Accept: text/plain

```

```javascript
const inputBody = '{
  "searchTerm": "The Green"
}';
const headers = {
  'Content-Type':'application/json',
  'Accept':'text/plain',
  'Authorization':'Bearer {access-token}'
};

fetch('/api/books/search',
{
  method: 'POST',
  body: inputBody,
  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```ruby
require 'rest-client'
require 'json'

headers = {
  'Content-Type' => 'application/json',
  'Accept' => 'text/plain',
  'Authorization' => 'Bearer {access-token}'
}

result = RestClient.post '/api/books/search',
  params: {
  }, headers: headers

p JSON.parse(result)

```

```python
import requests
headers = {
  'Content-Type': 'application/json',
  'Accept': 'text/plain',
  'Authorization': 'Bearer {access-token}'
}

r = requests.post('/api/books/search', headers = headers)

print(r.json())

```

```php
<?php

require 'vendor/autoload.php';

$headers = array(
    'Content-Type' => 'application/json',
    'Accept' => 'text/plain',
    'Authorization' => 'Bearer {access-token}',
);

$client = new \GuzzleHttp\Client();

// Define array of request body.
$request_body = array();

try {
    $response = $client->request('POST','/api/books/search', array(
        'headers' => $headers,
        'json' => $request_body,
       )
    );
    print_r($response->getBody()->getContents());
 }
 catch (\GuzzleHttp\Exception\BadResponseException $e) {
    // handle exception or api errors.
    print_r($e->getMessage());
 }

 // ...

```

```java
URL obj = new URL("/api/books/search");
HttpURLConnection con = (HttpURLConnection) obj.openConnection();
con.setRequestMethod("POST");
int responseCode = con.getResponseCode();
BufferedReader in = new BufferedReader(
    new InputStreamReader(con.getInputStream()));
String inputLine;
StringBuffer response = new StringBuffer();
while ((inputLine = in.readLine()) != null) {
    response.append(inputLine);
}
in.close();
System.out.println(response.toString());

```

```go
package main

import (
       "bytes"
       "net/http"
)

func main() {

    headers := map[string][]string{
        "Content-Type": []string{"application/json"},
        "Accept": []string{"text/plain"},
        "Authorization": []string{"Bearer {access-token}"},
    }

    data := bytes.NewBuffer([]byte{jsonReq})
    req, err := http.NewRequest("POST", "/api/books/search", data)
    req.Header = headers

    client := &http.Client{}
    resp, err := client.Do(req)
    // ...
}

```

`POST /api/books/search`

*Searches for books by title.*

> Body parameter

```json
{
  "searchTerm": "The Green"
}
```

<h3 id="searchbooksbytitleasync-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[SearchBookByTitleRequest](#schemasearchbookbytitlerequest)|false|none|

> Example responses

> 200 Response

```
[{"id":"EABAA778-F8F2-4491-B80D-F9B5B15A0237","title":"The Green Moon by John Doe","availableCopies":17,"nextAvailableCopyDate":"2023-12-25"}]
```

```json
[
  {
    "id": "EABAA778-F8F2-4491-B80D-F9B5B15A0237",
    "title": "The Green Moon by John Doe",
    "availableCopies": 17,
    "nextAvailableCopyDate": "2023-12-25"
  }
]
```

<h3 id="searchbooksbytitleasync-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|Inline|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|[ProblemDetails](#schemaproblemdetails)|

<h3 id="searchbooksbytitleasync-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[BookResponse](#schemabookresponse)]|false|none|none|
|» id|string(uuid)|true|none|The book id.|
|» title|string|true|none|The book title.|
|» availableCopies|integer(int32)|false|none|Total copies available in the library at the moment.|
|» nextAvailableCopyDate|string(date)¦null|false|none|The closest date when a borrowed copy will be returned.|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
oauth2 ( Scopes: openid )
</aside>

<h1 id="my-library-api-notifications">Notifications</h1>

## GetOwnUnreadNotificationsAsync

<a id="opIdGetOwnUnreadNotificationsAsync"></a>

> Code samples

```shell
# You can also use wget
curl -X GET /api/notifications/own/unread \
  -H 'Accept: text/plain' \
  -H 'Authorization: Bearer {access-token}'

```

```http
GET /api/notifications/own/unread HTTP/1.1

Accept: text/plain

```

```javascript

const headers = {
  'Accept':'text/plain',
  'Authorization':'Bearer {access-token}'
};

fetch('/api/notifications/own/unread',
{
  method: 'GET',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```ruby
require 'rest-client'
require 'json'

headers = {
  'Accept' => 'text/plain',
  'Authorization' => 'Bearer {access-token}'
}

result = RestClient.get '/api/notifications/own/unread',
  params: {
  }, headers: headers

p JSON.parse(result)

```

```python
import requests
headers = {
  'Accept': 'text/plain',
  'Authorization': 'Bearer {access-token}'
}

r = requests.get('/api/notifications/own/unread', headers = headers)

print(r.json())

```

```php
<?php

require 'vendor/autoload.php';

$headers = array(
    'Accept' => 'text/plain',
    'Authorization' => 'Bearer {access-token}',
);

$client = new \GuzzleHttp\Client();

// Define array of request body.
$request_body = array();

try {
    $response = $client->request('GET','/api/notifications/own/unread', array(
        'headers' => $headers,
        'json' => $request_body,
       )
    );
    print_r($response->getBody()->getContents());
 }
 catch (\GuzzleHttp\Exception\BadResponseException $e) {
    // handle exception or api errors.
    print_r($e->getMessage());
 }

 // ...

```

```java
URL obj = new URL("/api/notifications/own/unread");
HttpURLConnection con = (HttpURLConnection) obj.openConnection();
con.setRequestMethod("GET");
int responseCode = con.getResponseCode();
BufferedReader in = new BufferedReader(
    new InputStreamReader(con.getInputStream()));
String inputLine;
StringBuffer response = new StringBuffer();
while ((inputLine = in.readLine()) != null) {
    response.append(inputLine);
}
in.close();
System.out.println(response.toString());

```

```go
package main

import (
       "bytes"
       "net/http"
)

func main() {

    headers := map[string][]string{
        "Accept": []string{"text/plain"},
        "Authorization": []string{"Bearer {access-token}"},
    }

    data := bytes.NewBuffer([]byte{jsonReq})
    req, err := http.NewRequest("GET", "/api/notifications/own/unread", data)
    req.Header = headers

    client := &http.Client{}
    resp, err := client.Do(req)
    // ...
}

```

`GET /api/notifications/own/unread`

*Gets unread notifications for the logged in user.*

> Example responses

> 200 Response

```
[{"id":"4DAFDD3F-CBFE-4412-8690-15D25E771E13","message":"Your reservation for The Green Moon by John Doe has expired.","sentDate":"2023-12-25T06:00:00.000Z"}]
```

```json
[
  {
    "id": "4DAFDD3F-CBFE-4412-8690-15D25E771E13",
    "message": "Your reservation for The Green Moon by John Doe has expired.",
    "sentDate": "2023-12-25T06:00:00.000Z"
  }
]
```

<h3 id="getownunreadnotificationsasync-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|Inline|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|[ProblemDetails](#schemaproblemdetails)|

<h3 id="getownunreadnotificationsasync-responseschema">Response Schema</h3>

Status Code **200**

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|[[NotificationResponse](#schemanotificationresponse)]|false|none|none|
|» id|string(uuid)|false|none|The notification ID|
|» message|string|true|none|The notification message|
|» sentDate|string(date-time)|false|none|The date and time the notification was sent.|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
oauth2 ( Scopes: openid )
</aside>

## MarkOwnNotificationAsReadAsync

<a id="opIdMarkOwnNotificationAsReadAsync"></a>

> Code samples

```shell
# You can also use wget
curl -X POST /api/notifications/own/{id}/mark-as-read \
  -H 'Accept: text/plain' \
  -H 'Authorization: Bearer {access-token}'

```

```http
POST /api/notifications/own/{id}/mark-as-read HTTP/1.1

Accept: text/plain

```

```javascript

const headers = {
  'Accept':'text/plain',
  'Authorization':'Bearer {access-token}'
};

fetch('/api/notifications/own/{id}/mark-as-read',
{
  method: 'POST',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```ruby
require 'rest-client'
require 'json'

headers = {
  'Accept' => 'text/plain',
  'Authorization' => 'Bearer {access-token}'
}

result = RestClient.post '/api/notifications/own/{id}/mark-as-read',
  params: {
  }, headers: headers

p JSON.parse(result)

```

```python
import requests
headers = {
  'Accept': 'text/plain',
  'Authorization': 'Bearer {access-token}'
}

r = requests.post('/api/notifications/own/{id}/mark-as-read', headers = headers)

print(r.json())

```

```php
<?php

require 'vendor/autoload.php';

$headers = array(
    'Accept' => 'text/plain',
    'Authorization' => 'Bearer {access-token}',
);

$client = new \GuzzleHttp\Client();

// Define array of request body.
$request_body = array();

try {
    $response = $client->request('POST','/api/notifications/own/{id}/mark-as-read', array(
        'headers' => $headers,
        'json' => $request_body,
       )
    );
    print_r($response->getBody()->getContents());
 }
 catch (\GuzzleHttp\Exception\BadResponseException $e) {
    // handle exception or api errors.
    print_r($e->getMessage());
 }

 // ...

```

```java
URL obj = new URL("/api/notifications/own/{id}/mark-as-read");
HttpURLConnection con = (HttpURLConnection) obj.openConnection();
con.setRequestMethod("POST");
int responseCode = con.getResponseCode();
BufferedReader in = new BufferedReader(
    new InputStreamReader(con.getInputStream()));
String inputLine;
StringBuffer response = new StringBuffer();
while ((inputLine = in.readLine()) != null) {
    response.append(inputLine);
}
in.close();
System.out.println(response.toString());

```

```go
package main

import (
       "bytes"
       "net/http"
)

func main() {

    headers := map[string][]string{
        "Accept": []string{"text/plain"},
        "Authorization": []string{"Bearer {access-token}"},
    }

    data := bytes.NewBuffer([]byte{jsonReq})
    req, err := http.NewRequest("POST", "/api/notifications/own/{id}/mark-as-read", data)
    req.Header = headers

    client := &http.Client{}
    resp, err := client.Do(req)
    // ...
}

```

`POST /api/notifications/own/{id}/mark-as-read`

*Marks a notification as read.*

<h3 id="markownnotificationasreadasync-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|id|path|string(uuid)|true|The notification ID.|

> Example responses

> 401 Response

```
{"type":"string","title":"string","status":0,"detail":"string","instance":"string","property1":null,"property2":null}
```

```json
{
  "type": "string",
  "title": "string",
  "status": 0,
  "detail": "string",
  "instance": "string",
  "property1": null,
  "property2": null
}
```

<h3 id="markownnotificationasreadasync-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|None|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|[ProblemDetails](#schemaproblemdetails)|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Not Found|[ProblemDetails](#schemaproblemdetails)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
oauth2 ( Scopes: openid )
</aside>

## MarkOwnNotificationsAsReadAsync

<a id="opIdMarkOwnNotificationsAsReadAsync"></a>

> Code samples

```shell
# You can also use wget
curl -X POST /api/notifications/own/mark-as-read \
  -H 'Accept: text/plain' \
  -H 'Authorization: Bearer {access-token}'

```

```http
POST /api/notifications/own/mark-as-read HTTP/1.1

Accept: text/plain

```

```javascript

const headers = {
  'Accept':'text/plain',
  'Authorization':'Bearer {access-token}'
};

fetch('/api/notifications/own/mark-as-read',
{
  method: 'POST',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```ruby
require 'rest-client'
require 'json'

headers = {
  'Accept' => 'text/plain',
  'Authorization' => 'Bearer {access-token}'
}

result = RestClient.post '/api/notifications/own/mark-as-read',
  params: {
  }, headers: headers

p JSON.parse(result)

```

```python
import requests
headers = {
  'Accept': 'text/plain',
  'Authorization': 'Bearer {access-token}'
}

r = requests.post('/api/notifications/own/mark-as-read', headers = headers)

print(r.json())

```

```php
<?php

require 'vendor/autoload.php';

$headers = array(
    'Accept' => 'text/plain',
    'Authorization' => 'Bearer {access-token}',
);

$client = new \GuzzleHttp\Client();

// Define array of request body.
$request_body = array();

try {
    $response = $client->request('POST','/api/notifications/own/mark-as-read', array(
        'headers' => $headers,
        'json' => $request_body,
       )
    );
    print_r($response->getBody()->getContents());
 }
 catch (\GuzzleHttp\Exception\BadResponseException $e) {
    // handle exception or api errors.
    print_r($e->getMessage());
 }

 // ...

```

```java
URL obj = new URL("/api/notifications/own/mark-as-read");
HttpURLConnection con = (HttpURLConnection) obj.openConnection();
con.setRequestMethod("POST");
int responseCode = con.getResponseCode();
BufferedReader in = new BufferedReader(
    new InputStreamReader(con.getInputStream()));
String inputLine;
StringBuffer response = new StringBuffer();
while ((inputLine = in.readLine()) != null) {
    response.append(inputLine);
}
in.close();
System.out.println(response.toString());

```

```go
package main

import (
       "bytes"
       "net/http"
)

func main() {

    headers := map[string][]string{
        "Accept": []string{"text/plain"},
        "Authorization": []string{"Bearer {access-token}"},
    }

    data := bytes.NewBuffer([]byte{jsonReq})
    req, err := http.NewRequest("POST", "/api/notifications/own/mark-as-read", data)
    req.Header = headers

    client := &http.Client{}
    resp, err := client.Do(req)
    // ...
}

```

`POST /api/notifications/own/mark-as-read`

*Marks all of the logged in users' notifications as read.*

> Example responses

> 401 Response

```
{"type":"string","title":"string","status":0,"detail":"string","instance":"string","property1":null,"property2":null}
```

```json
{
  "type": "string",
  "title": "string",
  "status": 0,
  "detail": "string",
  "instance": "string",
  "property1": null,
  "property2": null
}
```

<h3 id="markownnotificationsasreadasync-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|None|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|[ProblemDetails](#schemaproblemdetails)|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Not Found|[ProblemDetails](#schemaproblemdetails)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
oauth2 ( Scopes: openid )
</aside>

<h1 id="my-library-api-customers">Customers</h1>

## GetOwnProfileAsync

<a id="opIdGetOwnProfileAsync"></a>

> Code samples

```shell
# You can also use wget
curl -X GET /api/profiles/own \
  -H 'Accept: text/plain' \
  -H 'Authorization: Bearer {access-token}'

```

```http
GET /api/profiles/own HTTP/1.1

Accept: text/plain

```

```javascript

const headers = {
  'Accept':'text/plain',
  'Authorization':'Bearer {access-token}'
};

fetch('/api/profiles/own',
{
  method: 'GET',

  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```ruby
require 'rest-client'
require 'json'

headers = {
  'Accept' => 'text/plain',
  'Authorization' => 'Bearer {access-token}'
}

result = RestClient.get '/api/profiles/own',
  params: {
  }, headers: headers

p JSON.parse(result)

```

```python
import requests
headers = {
  'Accept': 'text/plain',
  'Authorization': 'Bearer {access-token}'
}

r = requests.get('/api/profiles/own', headers = headers)

print(r.json())

```

```php
<?php

require 'vendor/autoload.php';

$headers = array(
    'Accept' => 'text/plain',
    'Authorization' => 'Bearer {access-token}',
);

$client = new \GuzzleHttp\Client();

// Define array of request body.
$request_body = array();

try {
    $response = $client->request('GET','/api/profiles/own', array(
        'headers' => $headers,
        'json' => $request_body,
       )
    );
    print_r($response->getBody()->getContents());
 }
 catch (\GuzzleHttp\Exception\BadResponseException $e) {
    // handle exception or api errors.
    print_r($e->getMessage());
 }

 // ...

```

```java
URL obj = new URL("/api/profiles/own");
HttpURLConnection con = (HttpURLConnection) obj.openConnection();
con.setRequestMethod("GET");
int responseCode = con.getResponseCode();
BufferedReader in = new BufferedReader(
    new InputStreamReader(con.getInputStream()));
String inputLine;
StringBuffer response = new StringBuffer();
while ((inputLine = in.readLine()) != null) {
    response.append(inputLine);
}
in.close();
System.out.println(response.toString());

```

```go
package main

import (
       "bytes"
       "net/http"
)

func main() {

    headers := map[string][]string{
        "Accept": []string{"text/plain"},
        "Authorization": []string{"Bearer {access-token}"},
    }

    data := bytes.NewBuffer([]byte{jsonReq})
    req, err := http.NewRequest("GET", "/api/profiles/own", data)
    req.Header = headers

    client := &http.Client{}
    resp, err := client.Do(req)
    // ...
}

```

`GET /api/profiles/own`

*Gets the profile of the logged in user.*

> Example responses

> 200 Response

```
{"fullName":"John Doe","emailAddress":"john@email.com","totalUnreadNotifications":1,"totalBorrowedBooks":1,"totalReservedBooks":0}
```

```json
{
  "fullName": "John Doe",
  "emailAddress": "john@email.com",
  "totalUnreadNotifications": 1,
  "totalBorrowedBooks": 1,
  "totalReservedBooks": 0
}
```

<h3 id="getownprofileasync-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|[ProfileResponse](#schemaprofileresponse)|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|[ProblemDetails](#schemaproblemdetails)|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|Not Found|[ProblemDetails](#schemaproblemdetails)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
oauth2 ( Scopes: openid )
</aside>

## UpdateProfileAsync

<a id="opIdUpdateProfileAsync"></a>

> Code samples

```shell
# You can also use wget
curl -X POST /api/profile \
  -H 'Content-Type: application/json' \
  -H 'Accept: text/plain' \
  -H 'Authorization: Bearer {access-token}'

```

```http
POST /api/profile HTTP/1.1

Content-Type: application/json
Accept: text/plain

```

```javascript
const inputBody = '{
  "fullName": "John Doe",
  "emailAddress": "john@email.com"
}';
const headers = {
  'Content-Type':'application/json',
  'Accept':'text/plain',
  'Authorization':'Bearer {access-token}'
};

fetch('/api/profile',
{
  method: 'POST',
  body: inputBody,
  headers: headers
})
.then(function(res) {
    return res.json();
}).then(function(body) {
    console.log(body);
});

```

```ruby
require 'rest-client'
require 'json'

headers = {
  'Content-Type' => 'application/json',
  'Accept' => 'text/plain',
  'Authorization' => 'Bearer {access-token}'
}

result = RestClient.post '/api/profile',
  params: {
  }, headers: headers

p JSON.parse(result)

```

```python
import requests
headers = {
  'Content-Type': 'application/json',
  'Accept': 'text/plain',
  'Authorization': 'Bearer {access-token}'
}

r = requests.post('/api/profile', headers = headers)

print(r.json())

```

```php
<?php

require 'vendor/autoload.php';

$headers = array(
    'Content-Type' => 'application/json',
    'Accept' => 'text/plain',
    'Authorization' => 'Bearer {access-token}',
);

$client = new \GuzzleHttp\Client();

// Define array of request body.
$request_body = array();

try {
    $response = $client->request('POST','/api/profile', array(
        'headers' => $headers,
        'json' => $request_body,
       )
    );
    print_r($response->getBody()->getContents());
 }
 catch (\GuzzleHttp\Exception\BadResponseException $e) {
    // handle exception or api errors.
    print_r($e->getMessage());
 }

 // ...

```

```java
URL obj = new URL("/api/profile");
HttpURLConnection con = (HttpURLConnection) obj.openConnection();
con.setRequestMethod("POST");
int responseCode = con.getResponseCode();
BufferedReader in = new BufferedReader(
    new InputStreamReader(con.getInputStream()));
String inputLine;
StringBuffer response = new StringBuffer();
while ((inputLine = in.readLine()) != null) {
    response.append(inputLine);
}
in.close();
System.out.println(response.toString());

```

```go
package main

import (
       "bytes"
       "net/http"
)

func main() {

    headers := map[string][]string{
        "Content-Type": []string{"application/json"},
        "Accept": []string{"text/plain"},
        "Authorization": []string{"Bearer {access-token}"},
    }

    data := bytes.NewBuffer([]byte{jsonReq})
    req, err := http.NewRequest("POST", "/api/profile", data)
    req.Header = headers

    client := &http.Client{}
    resp, err := client.Do(req)
    // ...
}

```

`POST /api/profile`

*Updates the logged in user's profile.*

> Body parameter

```json
{
  "fullName": "John Doe",
  "emailAddress": "john@email.com"
}
```

<h3 id="updateprofileasync-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|body|body|[UpdateProfileRequest](#schemaupdateprofilerequest)|false|The request.|

> Example responses

> 401 Response

```
{"type":"string","title":"string","status":0,"detail":"string","instance":"string","property1":null,"property2":null}
```

```json
{
  "type": "string",
  "title": "string",
  "status": 0,
  "detail": "string",
  "instance": "string",
  "property1": null,
  "property2": null
}
```

<h3 id="updateprofileasync-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Success|None|
|401|[Unauthorized](https://tools.ietf.org/html/rfc7235#section-3.1)|Unauthorized|[ProblemDetails](#schemaproblemdetails)|

<aside class="warning">
To perform this operation, you must be authenticated by means of one of the following methods:
oauth2 ( Scopes: openid )
</aside>

# Schemas

<h2 id="tocS_AddBookRequest">AddBookRequest</h2>
<!-- backwards compatibility -->
<a id="schemaaddbookrequest"></a>
<a id="schema_AddBookRequest"></a>
<a id="tocSaddbookrequest"></a>
<a id="tocsaddbookrequest"></a>

```json
{
  "id": "EABAA778-F8F2-4491-B80D-F9B5B15A0237",
  "title": "The Green Moon by John Doe",
  "numberOfCopies": 18
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|id|string(uuid)|true|none|Required: The book ID.|
|title|string|true|none|Required: The book title.|
|numberOfCopies|integer(int32)|false|none|The number of copies. Should be between 1 and 1000.|

<h2 id="tocS_BookResponse">BookResponse</h2>
<!-- backwards compatibility -->
<a id="schemabookresponse"></a>
<a id="schema_BookResponse"></a>
<a id="tocSbookresponse"></a>
<a id="tocsbookresponse"></a>

```json
{
  "id": "EABAA778-F8F2-4491-B80D-F9B5B15A0237",
  "title": "The Green Moon by John Doe",
  "availableCopies": 17,
  "nextAvailableCopyDate": "2023-12-25"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|id|string(uuid)|true|none|The book id.|
|title|string|true|none|The book title.|
|availableCopies|integer(int32)|false|none|Total copies available in the library at the moment.|
|nextAvailableCopyDate|string(date)¦null|false|none|The closest date when a borrowed copy will be returned.|

<h2 id="tocS_BorrowBookRequest">BorrowBookRequest</h2>
<!-- backwards compatibility -->
<a id="schemaborrowbookrequest"></a>
<a id="schema_BorrowBookRequest"></a>
<a id="tocSborrowbookrequest"></a>
<a id="tocsborrowbookrequest"></a>

```json
{
  "returnDate": "2023-12-25"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|returnDate|string(date)|false|none|The date on which the customer expects to return the book.|

<h2 id="tocS_BorrowedBookResponse">BorrowedBookResponse</h2>
<!-- backwards compatibility -->
<a id="schemaborrowedbookresponse"></a>
<a id="schema_BorrowedBookResponse"></a>
<a id="tocSborrowedbookresponse"></a>
<a id="tocsborrowedbookresponse"></a>

```json
{
  "id": "EABAA778-F8F2-4491-B80D-F9B5B15A0237",
  "title": "The Green Moon by John Doe",
  "dueDate": "2023-12-25"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|id|string(uuid)|false|none|The book id.|
|title|string|true|none|The book title.|
|dueDate|string(date)|false|none|The date by which the book should be returned.|

<h2 id="tocS_NotificationResponse">NotificationResponse</h2>
<!-- backwards compatibility -->
<a id="schemanotificationresponse"></a>
<a id="schema_NotificationResponse"></a>
<a id="tocSnotificationresponse"></a>
<a id="tocsnotificationresponse"></a>

```json
{
  "id": "4DAFDD3F-CBFE-4412-8690-15D25E771E13",
  "message": "Your reservation for The Green Moon by John Doe has expired.",
  "sentDate": "2023-12-25T06:00:00.000Z"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|id|string(uuid)|false|none|The notification ID|
|message|string|true|none|The notification message|
|sentDate|string(date-time)|false|none|The date and time the notification was sent.|

<h2 id="tocS_ProblemDetails">ProblemDetails</h2>
<!-- backwards compatibility -->
<a id="schemaproblemdetails"></a>
<a id="schema_ProblemDetails"></a>
<a id="tocSproblemdetails"></a>
<a id="tocsproblemdetails"></a>

```json
{
  "type": "string",
  "title": "string",
  "status": 0,
  "detail": "string",
  "instance": "string",
  "property1": null,
  "property2": null
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|**additionalProperties**|any|false|none|none|
|type|string¦null|false|none|none|
|title|string¦null|false|none|none|
|status|integer(int32)¦null|false|none|none|
|detail|string¦null|false|none|none|
|instance|string¦null|false|none|none|

<h2 id="tocS_ProfileResponse">ProfileResponse</h2>
<!-- backwards compatibility -->
<a id="schemaprofileresponse"></a>
<a id="schema_ProfileResponse"></a>
<a id="tocSprofileresponse"></a>
<a id="tocsprofileresponse"></a>

```json
{
  "fullName": "John Doe",
  "emailAddress": "john@email.com",
  "totalUnreadNotifications": 1,
  "totalBorrowedBooks": 1,
  "totalReservedBooks": 0
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|fullName|string|true|none|The user's full name.|
|emailAddress|string|true|none|The user's email address.|
|totalUnreadNotifications|integer(int32)|false|none|The user's total unread notifications|
|totalBorrowedBooks|integer(int32)|false|none|The number of borrowed books the user has not returned yet.|
|totalReservedBooks|integer(int32)|false|none|The number of books the user has reserved.|

<h2 id="tocS_ReservedBookResponse">ReservedBookResponse</h2>
<!-- backwards compatibility -->
<a id="schemareservedbookresponse"></a>
<a id="schema_ReservedBookResponse"></a>
<a id="tocSreservedbookresponse"></a>
<a id="tocsreservedbookresponse"></a>

```json
{
  "id": "EABAA778-F8F2-4491-B80D-F9B5B15A0237",
  "title": "The Green Moon by John Doe",
  "reservationExpiryDate": "2023-12-25T06:00:00.000Z"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|id|string(uuid)|false|none|The book id.|
|title|string|true|none|The book title.|
|reservationExpiryDate|string(date-time)|false|none|The date and time on which the reservation will expire.|

<h2 id="tocS_SearchBookByTitleRequest">SearchBookByTitleRequest</h2>
<!-- backwards compatibility -->
<a id="schemasearchbookbytitlerequest"></a>
<a id="schema_SearchBookByTitleRequest"></a>
<a id="tocSsearchbookbytitlerequest"></a>
<a id="tocssearchbookbytitlerequest"></a>

```json
{
  "searchTerm": "The Green"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|searchTerm|string|true|none|The search term.|

<h2 id="tocS_UpdateProfileRequest">UpdateProfileRequest</h2>
<!-- backwards compatibility -->
<a id="schemaupdateprofilerequest"></a>
<a id="schema_UpdateProfileRequest"></a>
<a id="tocSupdateprofilerequest"></a>
<a id="tocsupdateprofilerequest"></a>

```json
{
  "fullName": "John Doe",
  "emailAddress": "john@email.com"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|fullName|string|true|none|The first and last name.|
|emailAddress|string(email)|true|none|The email address.|

