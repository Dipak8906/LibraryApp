import { Component, OnInit } from '@angular/core';

import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-ebook',
  templateUrl: './show-ebook.component.html',
  styleUrls: ['./show-ebook.component.css']
})
export class ShowEBookComponent implements OnInit {

  constructor( private service:SharedService) { }

  EBookList:any=[];
  Modaltitle?:string;
  activateAddEditEBookComp:boolean=false;
  eBook:any;
  ByIdFilter:string="";
  ByNameFilter:string="";
  ListWithoutFilter:any=[];
  ngOnInit(): void {
    this.refreshEBookList();
  }

  addClick(){
    this.eBook={
      eBookId:0,
      eBookName:"",
      isbn:"",
      description:"",
      publisher:"",
      author:""
    }
    this.Modaltitle="Add EBook";
    this.activateAddEditEBookComp=true;
  }

  editClick(item:any)
  {
    this.eBook=item;
    this.Modaltitle="Edit EBook";
    this.activateAddEditEBookComp=true;
  }

  deleteClick(item:any)
  {
    if(confirm('Are you sure want to delete this EBook'))
    {
      this.service.deleteEBook(item.eBookId).subscribe(data=>{
        alert(data.toString());
        this.refreshEBookList();
      });    }
  }

  closeClick()
  {
    this.activateAddEditEBookComp=false;
    this.refreshEBookList();
  }

  refreshEBookList()
  {
    this.service.getEBookList().subscribe(data=>{
      this.EBookList=data;
      this.ListWithoutFilter=data;
    });
  }

 FilterFn(){
    var ByIdFilter = this.ByIdFilter;
    var ByNameFilter = this.ByNameFilter;

    this.EBookList = this.ListWithoutFilter.filter(function (el:any){
        return el.ebookId.toString().toLowerCase().includes(
          ByIdFilter.toString().trim().toLowerCase()
        )&&
        el.ebookName.toString().toLowerCase().includes(
          ByNameFilter.toString().trim().toLowerCase()
        )
    });
  }


}
