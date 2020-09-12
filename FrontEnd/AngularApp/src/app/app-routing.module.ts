import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { SignupComponent } from './Auth/signup/signup.component';
import { SigninComponent } from './Auth/signin/signin.component';
import { AuthGuard } from './Auth/auth.guard';
import { CategoriesComponent } from './categories/categories.component';
import { CategoryComponent } from './categories/category/category.component';
import { TestComponent } from './test/test.component';
import { TestquizComponent } from './test/testquiz/testquiz.component';
import { TestresultComponent } from './test/testresult/testresult.component';
import { AdminComponent } from './admin/admin.component';
import { UserprofileComponent } from './userprofile/userprofile.component';
import { ReportsComponent } from './reports/reports.component';
import { AdminGuard } from './Auth/admin.guard';
import { AccessdeniedComponent } from './Auth/accessdenied/accessdenied.component';
import { subcategory } from './categories/category.service';
import { FiltersubcategoryComponent } from './categories/filtersubcategory/filtersubcategory.component';


const routes: Routes = [
  { path: '', component: HomeComponent },
  {path : 'signup' , component : SignupComponent},
  {path : 'signin' , component : SigninComponent},
  { path: 'categories' , component : CategoriesComponent,
     children : [ { path : 'testall' , component : CategoryComponent},
                  { path : ':id', component: FiltersubcategoryComponent }
                ]
  },
  { path: 'test' , component : TestComponent , canActivate:[AuthGuard],
     children : [
          { path : 'results', component : TestresultComponent } ,
          { path : ':id', component: TestquizComponent }  
       ]
  },
  {  path : 'admin' , component : AdminComponent, canActivate:[AdminGuard] },
  { path: 'userprofile' , component : UserprofileComponent}, 
  { path : 'reports' , component : ReportsComponent},
  {path : 'accessdenied' , component : AccessdeniedComponent },
  
  
]


@NgModule({
  imports: [
    CommonModule,
    RouterModule.forRoot(routes,{useHash : true})
  ],
  exports: [RouterModule],
  declarations: [],
  providers: [AuthGuard],
})
export class AppRoutingModule { }
