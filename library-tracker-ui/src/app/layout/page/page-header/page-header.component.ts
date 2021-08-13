import { Component, Injector, Input, OnInit } from '@angular/core';
import { HeaderType } from '../enums/header-type';
import { BaseComponent } from '../../../shared/components/base.component';
import { PageService } from '../page.service';
import { Title } from '@angular/platform-browser';
import { InputSwitch } from 'primeng/inputswitch';
import { Theme } from 'src/app/shared/classes/user-settings';
import { NavPage } from 'src/app/shared/classes/globals';

@Component({
  selector: 'page-header',
  templateUrl: './page-header.component.html'
})
export class PageHeaderComponent extends BaseComponent implements OnInit {

  @Input() pageTitle: string = "";
  @Input() subTitle1: string = "";
  @Input() subTitle2: string = "";
  @Input() pageHint: string = "";
  @Input() headerType: HeaderType = HeaderType.Short;
  @Input('showback') showBackButton: boolean = false;
  public showOptions: boolean = false;
  public showSideOptions: boolean = false;
  public sideOptionsId: number = 0;
  public themes: Array<Theme> = new Array<Theme>();
  public navToggle: boolean = false;
  public navigationMenu: Array<NavPage> = new Array<NavPage>();
  public navLoaded: boolean = false;
  public selectedThemeStatus: boolean = false;

  constructor(private injector: Injector,
    private pageService: PageService,
    private titleService: Title) {
    super(injector);
   }

  ngOnInit(): void {
    if(this.globals.settings.theme.themeId == 1)
        this.selectedThemeStatus = true;

    this.pageService.getThemes().then((res: Array<Theme>) => {
      this.themes = res;
    }).catch((err: any) => {
      this.messageService.add({severity:'error', summary:'Error', detail:'Failed to get themes.', life: 2600 });
    });

    this.pageService.getNavMenu().then((res: Array<NavPage>) => {
      this.navigationMenu = res;
      this.navLoaded = true;
    }).catch((err: any) => {
      // Log Error
    });
  }

  public changeTheme(e: InputSwitch) {
    if(e.checked)
      this.globals.settings.theme = this.themes[0];
    else
      this.globals.settings.theme = this.themes[1];

    this.saveSettings();
  }

  public async saveSettings(): Promise<void> {
    this.loader.start();
    this.pageService.saveSettings().then(() => {
      this.loader.stop();
    }).catch((err: any) => {
      this.loader.stop();
    });
  }

  public async navToPage(navMenu: NavPage) {
    if(navMenu.navMenuRoute != "" || navMenu.navMenuRoute != undefined) {
      await this.router.navigate([navMenu.navMenuRoute]).then(() => {
        this.titleService.setTitle(this.globals.config.hubName + " - " + navMenu.navMenuName);
        this.globals.previousPage = this.globals.currentPage;
        this.globals.currentPage = navMenu;
      }).finally(() => {
        this.pageService.saveSettings();
      });
    }   
  }
}
