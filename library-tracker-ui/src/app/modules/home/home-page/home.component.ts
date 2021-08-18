import { HttpErrorResponse } from '@angular/common/http';
import { Component, Injector, OnInit } from '@angular/core';
import { debug } from 'console';
import { Book } from 'src/app/shared/classes/book';
import { BaseComponent } from 'src/app/shared/components/base.component';
import { HomeService } from '../home.service';

@Component({
  selector: 'home',
  templateUrl: './home.component.html'
})
export class HomeComponent extends BaseComponent implements OnInit {

  public searchISBN: string = "";
  public isLoaded: boolean = false;
  public bookFound: boolean = false;
  public bookToDisplay: Book = new Book;

  constructor(private injector: Injector,
              private homeService: HomeService) {
    super(injector);
  }

  ngOnInit(): void {
    this.isLoaded = true;
  }

  public async searchForBook(): Promise<void> {
    this.bookFound = false;
    this.bookToDisplay = new Book;
    this.loader.startBackground();
    await this.homeService.searchForBook(this.searchISBN).catch((err: HttpErrorResponse) => {
      this.loader.stopBackground();
    }).then((res: Book) => {
      if(res) {
        this.bookToDisplay = res;
        this.bookFound = true;
        console.log(this.bookToDisplay);
      }
      else {
        this.messageService.add({severity:'info', summary:'0 Results', detail:'Failed to find book', life: 2600 });
      }
      this.loader.stopBackground();
    });
  }

  public async addToLibrary(): Promise<void> {

  }
}
