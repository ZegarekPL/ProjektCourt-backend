# ProjektCourt
## Opis
Aplikacja do zarządzania kortami.

## Funkcjonalności
### Must-have
- Dodawanie kortów ( Tylko admin )
- Wyświetlanie kortów, wraz z sortowaniem ( Wszyscy użytkownicy, także nie zalogowani)
- Logowanie ( Wszyscy użytkownicy, także nie zalogowani)

### Other
- ocena kortów ( zalogowani użytkownicy )
- zarządzenie kortami ( Tylko admin )
- opinie o kortach ( Wszyscy użytkownicy, także niezalogowani)
- Opinie użytkownika

| **Must-have**                                         | **Typ**   | **Endpoint**                    |
|-------------------------------------------------------|-----------|---------------------------------|
| Dodawanie kortów                                      | POST      | /api/court                      |
| Edycja kortów                                         | PUT       | /api/court/{id}                 |
| Usuwanie kortów                                       | DELETE    | /api/court/{id}                 |
| Wyświetlanie kortów, wraz z sortowaniem               | GET       | /api/courts                     |
| Logowanie (Tylko osoba zalogowana może dodawać korty) |           | OAuth2 lub zwykły login i hasło |


| **Other**                           | **Typ**   | **Endpoint**            |
|-------------------------------------|-----------|-------------------------|
| Dodawanie komentarzy o kortach      | POST      | /api/court/{id}/comment | 
| Wyświetlanie komentarzy o kortach   | GET       | /api/court/{id}/comment |
| Wyświetlanie komentarzy użytkownika | GET       | /api/user/{id}/comment  |
| Ocena kortów                        | POST      | /api/court/{id}/grades  |


## Typ danych

Role:

| **Id (number)**      | **Role (String)**   |
|----------------------|---------------------|
| 1                    | User                |
| 2                    | Admin               |
|                      | Osoba niezalogowana |

Kort:

| **Id (number)**     | **Nazwa (String)**  | **Lokalizacja (Object)**  | **Typ nawierzchni (number)**  | **Komentarze (number)**            | **Ocena (Object)**                           |
|---------------------|---------------------|---------------------------|-------------------------------|------------------------------------|----------------------------------------------|
| 1                   | Kort 1              |  {locX, locY, nazwa }     | idNawierzchni                 | idKomentarzy                       |  {grade1, grade2, grade3, grade4, grade5 }   |


Typ Nawierzchni Kortów:

| **Id (number)**    | **Nazwa (String)**  |
|--------------------|---------------------|
| 1                  | Kort 1              |

Komentarze:

| **Id (number)**      | **Osoba (id osoby)**  | **Komentarz (id osoby)**  | **Data(Date)**  |
|----------------------|-----------------------|---------------------------|-----------------|
| 1                    | 1                     | Przykładowy komantarz     | Data            |

Ocena:

| **Id (number)**     | **Ocena (number)**  | **Osoba (id osoby)**  |
|---------------------|---------------------|-----------------------|
| 1                   | Od 1 do 5           | 1                     |

## Technologie
### Frontend
- React
- NextJs
- Typescriptt
- Tailwindcss
- Docker

### Backend
- .Net
- PostgresSQL
- Docker

## Details of project progress are in [project releases](https://github.com/ZegarekPL/ProjektCourt-backend/releases)
