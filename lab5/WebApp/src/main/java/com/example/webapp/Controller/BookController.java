package com.example.webapp.Controller;

import com.example.webapp.Model.Book;
import com.example.webapp.PaginationResponse;
import com.example.webapp.Service.BookService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.PageRequest;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.*;

@Controller
@RequestMapping("/books")
public class BookController {

    @Autowired
    private BookService bookService;

    @GetMapping
    public String showBooks(

            @RequestParam(defaultValue = "1") int page,
            @RequestParam(defaultValue = "10") int size,
            Model model
    ) {
        com.example.webapp.ResponseEntity<PaginationResponse<Book>> bookPage = bookService.getBooks(PageRequest.of(page, size));
        model.addAttribute("books", bookPage.data.data);
        model.addAttribute("currentPage", bookPage.data.PageNumber + 1);
        model.addAttribute("totalPages",
                (int) Math.ceil((double) bookPage.data.TotalItems / bookPage.data.PageSize));
        model.addAttribute("pageSize", bookPage.data.PageSize);
        model.addAttribute("currentPage", page);
        return "main-page";
    }

    @GetMapping("/create-edit/{id}")
    public String showForm(@PathVariable(name = "id", required = false) int id,
                           @RequestParam(name = "title", required = false) String title,
                           @RequestParam(name = "author", required = false) String author,
                           @RequestParam(name = "description", required = false) String description,
                           Model model) {
        Book book = new Book();
        book.setId(id);

        if(id != 0) {
            book.setTitle(title);
            book.setAuthor(author);
            book.setDescription(description);
        }

        model.addAttribute("book", book);
        return "create-edit";
    }

    @PostMapping
    public String saveBook(@ModelAttribute Book book) {
        // Perform validation and save/update logic
        if (book.getId() != 0) {
            // Existing book, update it
            bookService.updateBook(book);
        } else {
            // New book, create it
            bookService.createBook(book);
        }

        return "redirect:/books"; // Redirect to the book list or another appropriate page
    }

    @DeleteMapping("/{id}")
    public String deleteBook(@PathVariable Long id) {
        ResponseEntity<String> responseEntity = bookService.deleteBook(id);
        System.out.println(responseEntity.getStatusCode());
        System.out.println(id);
        return "redirect:/books";
    }
}

