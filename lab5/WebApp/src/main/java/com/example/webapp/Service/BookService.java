package com.example.webapp.Service;

import com.example.webapp.Model.Book;
import com.example.webapp.PaginationResponse;
import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.ObjectMapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Pageable;
import org.springframework.http.*;
import org.springframework.stereotype.Service;
import org.springframework.web.client.RestTemplate;
import org.springframework.web.reactive.function.client.WebClient;

@Service
public class BookService {

    private final WebClient.Builder webClientBuilder;

    @Autowired
    public BookService(WebClient.Builder webClientBuilder) {
        this.webClientBuilder = webClientBuilder;
    }

    private final String baseUrl = "http://localhost:5093/api/Book";
    public com.example.webapp.ResponseEntity<PaginationResponse<Book>> getBooks(Pageable pageable) {
        try {
            // Replace with your actual values
            String fullUrl = baseUrl + "/" + pageable.getPageNumber() + "/" + pageable.getPageSize();

            RestTemplate restTemplate = new RestTemplate();
            ResponseEntity<String> responseEntity = restTemplate.getForEntity(fullUrl, String.class);

            // Log the response body
            String responseBody = responseEntity.getBody();
            System.out.println("Response Body: " + responseBody);

            ObjectMapper objectMapper = new ObjectMapper();
            com.example.webapp.ResponseEntity<PaginationResponse<Book>> paginationResponse = objectMapper.readValue(responseBody,
                    new TypeReference<>() {});

            return paginationResponse;

        } catch (Exception e) {
            // Handle exception appropriately
            return new com.example.webapp.ResponseEntity();
        }
    }

    public ResponseEntity<String> deleteBook(Long bookId) {
        try {

            RestTemplate restTemplate = new RestTemplate();
            // Replace with your actual values
            ResponseEntity<String> responseEntity = restTemplate.exchange(
                    baseUrl + "/" + bookId,
                    HttpMethod.DELETE,
                    null,   // No request body for DELETE
                    String.class
            );
            // Get the response body and status code
            String responseBody = responseEntity.getBody();
            int statusCode = responseEntity.getStatusCodeValue();

            System.out.println("Response Body: " + responseBody);
            System.out.println("Status Code: " + statusCode);

            return ResponseEntity.accepted().build();
        } catch (Exception e) {
            // Handle exception appropriately
            return ResponseEntity.badRequest().build();
        }
    }

    public void createBook(Book book) {
        // Prepare the request headers
        HttpHeaders headers = new HttpHeaders();
        headers.setContentType(MediaType.APPLICATION_JSON);

        // Prepare the request entity with the book data
        HttpEntity<Book> requestEntity = new HttpEntity<>(book, headers);

        // Make the POST request to create a new book
        ResponseEntity<Void> responseEntity = new RestTemplate().postForEntity(baseUrl, requestEntity, Void.class);
        System.out.println(responseEntity);
    }

    public void updateBook(Book book) {
        // Prepare the request headers
        HttpHeaders headers = new HttpHeaders();
        headers.setContentType(MediaType.APPLICATION_JSON);

        // Prepare the request entity with the book data
        HttpEntity<Book> requestEntity = new HttpEntity<>(book, headers);

        // Make the PUT request to update the book
        new RestTemplate().put(baseUrl, requestEntity);

        // Handle the response if needed
        // ...
    }
}
