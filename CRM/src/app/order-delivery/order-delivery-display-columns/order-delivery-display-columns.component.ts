import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { OrderDeliveryService } from 'src/app/shared/OrderDelivery.service';
@Component({
  selector: 'app-order-delivery-display-columns',
  templateUrl: './order-delivery-display-columns.component.html',
  styleUrls: ['./order-delivery-display-columns.component.css']
})
export class OrderDeliveryDisplayColumnsComponent implements OnInit {

  constructor(
    public OrderDeliveryService: OrderDeliveryService,
    public dialogRef: MatDialogRef<OrderDeliveryDisplayColumnsComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) { }

  ngOnInit(): void {
  }
  onClose() {
    this.dialogRef.close();
  }  
}
