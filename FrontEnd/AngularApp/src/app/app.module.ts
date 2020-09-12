import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { FooterComponent } from './footer/footer.component';
import { SignupComponent } from './Auth/signup/signup.component';
import { SigninComponent } from './Auth/signin/signin.component';
import { AuthService } from './Auth/auth.service';
import { ToastrService } from './toastr.service';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HomeComponent } from './home/home.component';
import { AppRoutingModule } from './app-routing.module';
import { AuthGuard } from './auth/auth.guard';
import { CategoriesComponent } from './categories/categories.component';
import { CategoryComponent } from './categories/category/category.component';
import { CategoryService } from './categories/category.service';
import { TestComponent } from './test/test.component';
import { TestquizComponent } from './test/testquiz/testquiz.component';
import { QuizService } from './test/quiz.service';
import { TestresultComponent } from './test/testresult/testresult.component';
import { AdminComponent } from './admin/admin.component';
import { CategoryComponentComponent } from './admin/category-component/category-component.component';
import { SubcategoryComponent } from './admin/subcategory/subcategory.component';
import { TopicsComponent } from './admin/topics/topics.component';
import { Tab } from './admin/tab/tab.component';
import { Tabset } from './admin/tabset/tabset.component';
import { OasService } from './oas.service';
import { ReportsComponent } from './reports/reports.component';
import { CompetencyComponent } from './reports/competency/competency.component';
import { SubskillComponent } from './reports/subskill/subskill.component';
import { ChartsModule } from 'ng2-charts'
import { UserprofileComponent } from './userprofile/userprofile.component';
import { TopicFilterPipe } from './categories/topic-filter.pipe';
import { AccessdeniedComponent } from './Auth/accessdenied/accessdenied.component';
import { FiltersubcategoryComponent } from './categories/filtersubcategory/filtersubcategory.component';


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    FooterComponent,
    SignupComponent,
    SigninComponent,
    HomeComponent,  
    CategoriesComponent,
    CategoryComponent,
    TestquizComponent,
    TestComponent,
    TestresultComponent,
    AdminComponent,
    CategoryComponentComponent,
    SubcategoryComponent,
    TopicsComponent,
    Tab,
    Tabset,
    ReportsComponent,
    CompetencyComponent,
    SubskillComponent,
    UserprofileComponent,
    TopicFilterPipe,
    AccessdeniedComponent,
    FiltersubcategoryComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    ChartsModule
  ],
  providers: [ToastrService,AuthService,CategoryService,QuizService,OasService],
  bootstrap: [AppComponent,NavbarComponent,FooterComponent]
})
export class AppModule { }
