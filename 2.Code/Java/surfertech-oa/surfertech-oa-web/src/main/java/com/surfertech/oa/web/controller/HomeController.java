package com.surfertech.oa.web.controller;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;

/**
 * Created by qmcheng on 2017/1/11 0011.
 */
@Controller
@RequestMapping("")
public class HomeController {
    @RequestMapping
    public String index() {
        return "index";
    }
}
