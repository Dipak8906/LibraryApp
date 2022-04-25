import { Component, OnInit } from '@angular/core';

import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-supplier',
  templateUrl: './show-supplier.component.html',
  styleUrls: ['./show-supplier.component.css']
})
export class ShowSupplierComponent implements OnInit {

  constructor(private service:SharedService) { }

  
  SupplierList:any=[];
  Modaltitle?:string;
  activateAddEditSupplierComp:boolean=false;
  supplier:any;
  ByIdFilter:string="";
  ByNameFilter:string="";
  ListWithoutFilter:any=[];
  ngOnInit(): void {
    this.refreshSupplierList();
  }
 

  addClick(){
    this.supplier={
      supplierId:0,
      supplierName:"",
      purchaseNumber:0,
     
    }
    this.Modaltitle="Add supplier";
    this.activateAddEditSupplierComp=true;
  }

  editClick(item:any)
  {
    this.supplier=item;
    this.Modaltitle="Edit supplier";
    this.activateAddEditSupplierComp=true;
  }

  deleteClick(item:any)
  {
    if(confirm('Are you sure want to delete this supplier'))
    {
      this.service.deleteSupplier(item.supplierId).subscribe(data=>{
        alert(data.toString());
        this.refreshSupplierList();
      });    }
  }

  closeClick()
  {
    this.activateAddEditSupplierComp=false;
    this.refreshSupplierList();
  }

  refreshSupplierList()
  {
    this.service.getSupplierList().subscribe(data=>{
      this.SupplierList=data;
       this.ListWithoutFilter=data;
    });
  }

  FilterFn(){
    var ByIdFilter = this.ByIdFilter;
    var ByNameFilter = this.ByNameFilter;

    this.SupplierList = this.ListWithoutFilter.filter(function (el:any){
        return el.supplierId.toString().toLowerCase().includes(
          ByIdFilter.toString().trim().toLowerCase()
        )&&
        el.supplierName.toString().toLowerCase().includes(
          ByNameFilter.toString().trim().toLowerCase()
        )
    });
  }


}
