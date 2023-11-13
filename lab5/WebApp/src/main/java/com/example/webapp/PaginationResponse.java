package com.example.webapp;

import com.example.webapp.Model.Book;
import lombok.Data;

import java.util.List;

@Data
public class PaginationResponse<Book> {

    public List<Book> data;
    public int TotalItems;
    public int PageNumber;
    public int PageSize;

}
