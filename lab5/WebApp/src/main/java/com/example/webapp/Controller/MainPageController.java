package com.example.webapp.Controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;

@Controller
public class MainPageController {

    @Autowired
    public BookController bookController;

    @GetMapping("/")
    public String loadMainPage(Model model) {
        model.addAttribute("currentPage", 0);
        return "main-page";
    }
}
