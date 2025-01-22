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
| Dodawanie kortów                                      | POST      | /api/court/add                  |
| Edycja kortów                                         | PUT       | /api/court/{courtId}/edit       |
| Usuwanie kortów                                       | DELETE    | /api/court/{courtId}/delete     |
| Wyświetlanie kortów, wraz z sortowaniem               | GET       | /api/court/getAll               |
| Logowanie (Tylko osoba zalogowana może dodawać korty) |           | OAuth2 lub zwykły login i hasło |


| **Other**                                 | **Typ**   | **Endpoint**                         |
|-------------------------------------------|-----------|--------------------------------------|
| Wyświetlanie kortu, wraz z sortowaniem    | GET       | /api/court/{courtId}                 |
| Wyświetlanie ocen o kortach               | GET       | /api/grade/getAll                    |
| Dodawanie ocen do kortów                  | POST      | /api/grade/{userId}/court/{courtId}  |
| Edycja ocen kortów                        | PUT       | /api/grade/{userId}/court/{courtId}  |
| Wyświetlanie typów podłoża kortu          | GET       | /api/surfaceType                     |
| Dodawanie nowych typów podłoża kortu      | POST      | /api/surfaceType/addNewSurfaceType   |
| Rejestracja użytkowników                  | POST      | /api/user/register                   |
| Zmiana roli użytkowników                  | PUT       | /api/user/{userId}/role              |


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

## How to run:

### All in docker:

To bring up the application using Docker Compose, run the following command:

```bash
docker-compose -f docker-compose-app.yml up -d --build
```

To close it:

```bash
docker-compose -f docker-compose-app.yml down
```

### Database in docker, backend in native:

To bring up only database using Docker Compose, run the following command:

```bash
docker-compose up -d --build
```

To close it:

```bash
docker-compose down
```

### To Clear Unused Docker Resources

To clean up unused Docker resources and free up disk space:

```bash
docker system prune -a
```

To clean up unused Docker Images and free up disk space:

```bash
docker image prune -a
```

To clean up unused Docker Volumes and free up disk space:

```bash
docker volume prune -a
```
