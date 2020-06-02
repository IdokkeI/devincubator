import { Component, OnInit, Output } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ServicesService } from '../services/services.service';

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.css']
})

export class ChartComponent implements OnInit {

  arrX: Array<any> = [];
  arrY: Array<any> = [];

  chartForm: FormGroup;

  chartOptions = {
    responsive: true
  };
  chartData = [
    { data: this.arrY }
  ];
  chartLabels = this.arrX;



  constructor(
    private formBuilder: FormBuilder,
    private sendSevice: ServicesService
  ) {
    this.chartForm = formBuilder.group({
      a:['', Validators.required],
      b:['', Validators.required],
      c:['', Validators.required],
      step:['', Validators.required],
      rangefrom:['', Validators.required],
      rangeto:['', Validators.required]
    });
  }

  ngOnInit(): void {
  }

  send(){

    this.sendSevice.send(this.chartForm.value).subscribe(res => {

      console.log(this.arrY, this.arrX);

        for (let index = this.chartForm.value['rangefrom']; index <= this.chartForm.value['rangeto']; index++){

          this.arrX.push(index);
          this.arrY.push(res[index]);
        }
        console.log(this.arrY, this.arrX);
    });
  }

  get a(){
    return this.chartForm.get('a');
  }
  get b(){
    return this.chartForm.get('b');
  }
  get c(){
    return this.chartForm.get('c');
  }
  get step(){
    return this.chartForm.get('step');
  }
  get rangefrom(){
    return this.chartForm.get('rangefrom');
  }
  get rangeto(){
    return this.chartForm.get('rangeto');
  }
}
