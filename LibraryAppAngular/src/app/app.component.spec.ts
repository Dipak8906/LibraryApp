import { TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { AppComponent } from './app.component';
import {HttpClientTestingModule}from '@angular/common/http/testing'
import { BookComponent } from './book/book.component';
import { StudentComponent } from './student/student.component';
import { SharedService } from './shared.service';
import { ShowBookComponent } from './book/show-book/show-book.component';
import { SupplierComponent } from './supplier/supplier.component';
import { AddEditBookComponent } from './book/add-edit-book/add-edit-book.component';
import { ShowStudentComponent } from './student/show-student/show-student.component';
import { AddEditStudentComponent } from './student/add-edit-student/add-edit-student.component';
import { ShowSupplierComponent } from './supplier/show-supplier/show-supplier.component';


describe('AppComponent', () => {
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        RouterTestingModule,
        HttpClientTestingModule
       
      ],
      providers:[SharedService],
     
      declarations: [
        AppComponent,
        
      ],
    }).compileComponents();
  });

  it('should create the app', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app).toBeTruthy();
  });

  it(`should have as title 'LibraryManagementSystemAngular'`, () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app.title).toEqual('LibraryManagementSystemAngular');
  });

  it('should render title', () => {
    const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    const compiled = fixture.nativeElement as HTMLElement;
    expect(compiled.querySelector('h3')?.textContent).toContain('WELCOME TO LIBRARY');
  });
});
