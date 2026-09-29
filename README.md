<div align="center">

# 🏃 Life4Sport

**Sklep internetowy z artykułami sportowymi zbudowany w architekturze mikroserwisów**

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet&logoColor=white)
![Vue](https://img.shields.io/badge/Vue-3-4FC08D?logo=vuedotjs&logoColor=white)
![Quasar](https://img.shields.io/badge/Quasar-2-1976D2?logo=quasar&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?logo=microsoftsqlserver&logoColor=white)
![RabbitMQ](https://img.shields.io/badge/RabbitMQ-FF6600?logo=rabbitmq&logoColor=white)
![Kafka](https://img.shields.io/badge/Kafka-231F20?logo=apachekafka&logoColor=white)
![Docker](https://img.shields.io/badge/Docker-2496ED?logo=docker&logoColor=white)

</div>

---

## 📖 O projekcie

Life4Sport to projekt e-commerce podzielony na niezależne mikroserwisy, komunikujące się przez **API Gateway** oraz **brokery wiadomości** (RabbitMQ / Kafka). Repozytorium zawiera część sklepową (dla klienta) oraz **Backoffice** (panel administracyjny).

## 🧱 Architektura

```
                    ┌──────────────┐
   Frontend (WWW) ─▶│  Gateway.Api │
                    └──────┬───────┘
      ┌──────────┬─────────┼──────────┬───────────┬──────────┐
      ▼          ▼         ▼          ▼           ▼          ▼
  Identity    Catalog    Basket     Order      Discount   Whislist / Comment
      │          │         │          │           │
      └──────────┴────┬────┴──────────┴───────────┘
                      ▼
            RabbitMQ / Kafka   ◀──▶   SQL Server (baza per serwis)
```

| Serwis | Odpowiedzialność |
|---|---|
| `Gateway.Api` | Punkt wejścia, routing żądań do serwisów |
| `Identity.Api` | Rejestracja, logowanie, JWT / cookie |
| `Catalog.Api` | Katalog produktów |
| `Basket.Api` | Koszyk |
| `Order.Api` | Zamówienia |
| `Discount.Api` | Rabaty i promocje |
| `Whislist.Api` | Lista życzeń |
| `Comment.Api` | Komentarze / opinie |
| `Jobs.Api`, `ServiceBroker.Api` | Zadania w tle i obsługa brokera |
| `Shared` / `Common` | Wspólne biblioteki (konfiguracja, autoryzacja, repozytoria, brokery) |
| `Backoffice/*` | Panel administracyjny: Identity, Management, Order, Raport, Refund, Home (Blazor) |
| `WWW` | Frontend – Vue 3 + Quasar + Pinia |

## 🛠️ Technologie

- **Backend:** C#, .NET 8, ASP.NET Core Web API, Entity Framework Core, MassTransit, Silverback
- **Frontend:** Vue 3, Quasar, TypeScript, Pinia
- **Dane:** SQL Server (osobna baza dla każdego serwisu)
- **Messaging:** RabbitMQ, Apache Kafka
- **Infrastruktura:** Docker, Docker Compose

## 🚀 Uruchomienie

### Wymagania
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/)
- [Node.js](https://nodejs.org/) (frontend)
- Dostępna instancja SQL Server

### 1. Konfiguracja sekretów

Żadne hasła ani klucze nie są przechowywane w repozytorium. Skopiuj plik przykładowy i uzupełnij własnymi wartościami:

```bash
cp .env.example .env
```

| Zmienna | Opis |
|---|---|
| `DB_HOST` | Adres serwera SQL Server |
| `DB_USER` / `DB_PASSWORD` | Dane logowania do bazy |
| `JWT_KEY` | Sekret do podpisywania tokenów JWT (min. 32 znaki) |
| `RABBITMQ_USER` / `RABBITMQ_PASSWORD` | Dane logowania do RabbitMQ |

Plik `.env` jest w `.gitignore`. Wartości w `appsettings.json` (`CHANGE_ME`) to tylko placeholdery — docker-compose nadpisuje je zmiennymi środowiskowymi (`ConnectionStrings__DefaultConnection`, `IdentityOptions__Jwt__PrivateKey`, …).

Uruchamiając serwis bez Dockera, ustaw te same wartości przez [User Secrets](https://learn.microsoft.com/aspnet/core/security/app-secrets):

```bash
cd Catalog.Api
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=...;Database=Sport4Life_Catalog;user id=...;password=...;TrustServerCertificate=True"
dotnet user-secrets set "IdentityOptions:Jwt:PrivateKey" "<losowy-sekret-min-32-znaki>"
```

### 2. Backend (Docker Compose)

```bash
docker compose up --build
```

| Usługa | Adres |
|---|---|
| Gateway | http://localhost:8000 |
| Identity | http://localhost:8010 |
| Catalog | http://localhost:8020 |
| Basket | http://localhost:8030 |
| Order | http://localhost:8040 |
| Discount | http://localhost:8050 |
| RabbitMQ UI | http://localhost:15672 |

### 3. Backoffice

```bash
cd Backoffice
docker compose up --build
```

### 4. Frontend

```bash
cd WWW
npm install
npx quasar dev
```

## 🔐 Bezpieczeństwo

- Sekrety trzymaj w `.env` / User Secrets / zmiennych środowiskowych — nigdy w kodzie.
- Przed użyciem na produkcji **zmień** wszystkie hasła i klucz `JWT_KEY` oraz włącz HTTPS i `Secure`/`HttpOnly` dla ciasteczek (domyślna konfiguracja jest developerska).

## 📂 Struktura repozytorium

```
Life4Sport/
├── Gateway.Api/  Identity.Api/  Catalog.Api/  Basket.Api/
├── Order.Api/    Discount.Api/  Whislist.Api/ Comment.Api/
├── Jobs.Api/     ServiceBroker.Api/
├── Backoffice/          # panel administracyjny
├── Shared/  Common/     # wspólne biblioteki
├── ProjectMigrations/   # migracje EF
├── WWW/                 # frontend Vue + Quasar
├── docker-compose.yml
└── .env.example
```

## 📄 Licencja

Projekt edukacyjny / portfolio. Dodaj wybraną licencję (np. MIT) w pliku `LICENSE`, jeśli chcesz udostępnić kod do ponownego użycia.
