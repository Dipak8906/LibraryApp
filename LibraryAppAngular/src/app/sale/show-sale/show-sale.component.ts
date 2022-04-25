import { Component, OnInit } from '@angular/core';

import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-sale',
  templateUrl: './show-sale.component.html',
  styleUrls: ['./show-sale.component.css']
})
export class ShowSaleComponent implements OnInit {

  constructor(private service:SharedService) { }
  
  SaleList:any=[];
  Modaltitle?:string;
  activateAddEditSaleComp:boolean=false;
  sale:any;
  ByIdFilter:string="";
  ByNameFilter:string="";
  ListWithoutFilter:any=[];

  ngOnInit(): void {
    this.refreshSaleList();
  }
  addClick(){
    this.sale={
      saleId:0,
      studentId:0,
      bookId:0,
      price:0
     
    }
    this.Modaltitle="Add sale";
    this.activateAddEditSaleComp=true;
  }

  editClick(item:any)
  {
    this.sale=item;
    this.Modaltitle="Edit sale";
    this.activateAddEditSaleComp=true;
  }

  deleteClick(item:any)
  {
    if(confirm('Are you sure want to delete this supplier'))
    {
      this.service.deleteSale(item.saleId).subscribe(data=>{
        alert(data.toString());
        this.refreshSaleList();
      });    }
  }

  closeClick()
  {
    this.activateAddEditSaleComp=false;
    this.refreshSaleList();
  }


  refreshSaleList()
  {
    this.service.getSaleList().subscribe(data=>{
      this.SaleList=data;
      this.ListWithoutFilter=data;
    });
  }

 FilterFn(){
    var ByIdFilter = this.ByIdFilter;
    var ByNameFilter = this.ByNameFilter;

    this.SaleList = this.ListWithoutFilter.filter(function (el:any){
        return el.saleId.toString().toLowerCase().includes(
          ByIdFilter.toString().trim().toLowerCase()
        )&&
        el.studentId.toString().toLowerCase().includes(
          ByNameFilter.toString().trim().toLowerCase()
        )
    });
  }



}
