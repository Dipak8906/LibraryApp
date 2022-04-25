import { Component, OnInit } from '@angular/core';

import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-student',
  templateUrl: './show-student.component.html',
  styleUrls: ['./show-student.component.css']
})
export class ShowStudentComponent implements OnInit {

  constructor(private service:SharedService) { }

  StudentList:any=[];
  Modaltitle?:string;
  activateAddEditStudentComp:boolean=false;
  student:any;

  ngOnInit(): void {
    this.refreshStudentList();
  }

  addClick(){
    this.student={
      studentId:0,
      studentName:"",
      studentEmail:"",
      fatherName:"",
      phone:"",
      address:"",
      class:"",
      rollNo:0
    }
    this.Modaltitle="Add Student";
    this.activateAddEditStudentComp=true;
  }

  editClick(item:any)
  {
    this.student=item;
    this.Modaltitle="Edit Student";
    this.activateAddEditStudentComp=true;
  }

  deleteClick(item:any)
  {
    if(confirm('Are you sure want to delete this Student'))
    {
      this.service.deleteStudent(item.studentId).subscribe(data=>{
        alert(data.toString());
        this.refreshStudentList();
      });    }
  }

  closeClick()
  {
    this.activateAddEditStudentComp=false;
    this.refreshStudentList();
  }


  refreshStudentList()
  {
    this.service.getStudentList().subscribe(data=>{
      this.StudentList=data;
    });
  }
}
