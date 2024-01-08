# PAMiW projek końcowy - Michał Szlązak

## Główne projekty
#### RestAPi
#### Blazor web application
#### Maui mobile application

## Zrealizowane zadania
### 1. Hosting API na Publicznym Serwerze
REST API zostało umieszczone za platformie Azure jako App Service. Wraz z Api na Azure został utworzony serwer bazodanowy oraz baza danych Sql.
  
Link do Api: https://pamiw-restapi.azurewebsites.net/.  
Przykładowe żądanie nie wymagające autentykacji:
https://pamiw-restapi.azurewebsites.net/api/Book/1/1

### 2. Hosting aplikacji webowej Blazor na publicznym serwerze
Aplikacja webowa Blazor została opublikowana na platformie azure jako Static Web App.
  
Link do strony: https://happy-beach-0de360f10.4.azurestaticapps.net

### 3. Udoskonalenie Interfejsu Aplikacji Mobilnej i Webowej
Zaimplementowane:
 - spójność wizualna: aplikacje wyświetlają informacje w zbliżony sposób, mają podobną paletę kolorów oraz responsywność na działania użytkownika.
 - Odpowiedź Interfejsu: Długie operacje są sygnalizowane ikoną ładowania, brak internetu również jest sygnalizowany.
 - Walidacja danych: podstawowe informowanie użytkownika o błędnie wypełnionym formularzu zostało zaimplementowane.

### 4. Ustawienia Użytkownika
Nie zostały zaimplementowane.

### 5. Opcje Logowania/Rejestracji
Opcje logowania i rejestracji jedynie w obrębie Rest Api.

### 6. Kompatybilność Aplikacji Mobilnej
Aplikacja mobilna MAUI jest kompatybilna z wcześniej wymienionym REST API i działa na Androidzie, Windowsie oraz MacOS.

### 7. Dostęp do Zasobów Sprzętowych
Aplikacja mobilna wymaga dostępu do informacji o połączeniu sieciowym.

###  8. Warstwa Serwisów Dla Aplikacji Webowej i Mobilnej
Obie aplikacje (Maui oraz Blazor) korzystają z wspólnych implementacji serwisów AuthService oraz BookService.
