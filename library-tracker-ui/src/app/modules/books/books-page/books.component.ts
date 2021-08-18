import { HttpErrorResponse } from '@angular/common/http';
import { Component, Injector, OnInit } from '@angular/core';
import { Book } from 'src/app/shared/classes/book';
import { BaseComponent } from 'src/app/shared/components/base.component';
import { BooksService } from '../books.service';

@Component({
  selector: 'books',
  templateUrl: './books.component.html'
})
export class BooksComponent extends BaseComponent implements OnInit {

  public isLoaded: boolean = false;
  public bookCollection: Array<Book> = new Array<Book>();
  constructor(private injector: Injector,
              private bookService: BooksService) {
    super(injector);
  }

  async ngOnInit(): Promise<void> {
    await this.loadBooks();
  }

  public async loadBooks(): Promise<void> {
    this.loader.start();
    await this.bookService.getBookCollection().catch((err: HttpErrorResponse) => {
      this.messageService.add({severity:'error', summary:'Error', detail:'Internal Server Error', life: 2600 });
    }).then((res: Array<Book>) => {
      if(res)
        this.bookCollection = res;
    }).finally(() => {
      this.isLoaded = true;
      this.loader.stop();
      console.log(this.bookCollection);
    });
  }
}
