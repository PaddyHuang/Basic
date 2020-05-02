# -*- coding: utf-8 -*-
import scrapy


class LianjiaSpider(scrapy.Spider):
    name = 'lianjia'
    allowed_domains = ['www.lianjia.com']
    start_urls = ['https://www.lianjia.com/']

    def parse(self, response):
        self.log(response.xpath('.//div/'))
