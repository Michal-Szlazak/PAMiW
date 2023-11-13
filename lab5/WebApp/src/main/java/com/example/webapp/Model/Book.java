package com.example.webapp.Model;

import lombok.Builder;
import lombok.Data;

@Data
public class Book {

    public Book() {

    }
    public int Id;
    public String Title;
    public String Author;
    public String description;

}
