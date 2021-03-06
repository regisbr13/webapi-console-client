import { Component, OnInit } from '@angular/core';
import { ComputerService } from '../services/Computer.service';
import { Computer } from '../models/Computer';
import { Scheduling } from '../models/Scheduling';
import { SchedulingService } from '../services/Scheduling.service';
import { HttpClient } from '@angular/common/http';
import { BsDatepickerConfig, BsModalService } from 'ngx-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { Title } from '@angular/platform-browser';
import { DatePipe } from '@angular/common';


@Component({
  selector: 'app-computers',
  templateUrl: './computers.component.html',
  styleUrls: ['./computers.component.css']
})
export class ComputersComponent implements OnInit {
  computers: Computer[] = [];
  terminal = false;
  title = 'Computadores do usuário'
  comand: string;
  scheduling: Scheduling;
  computerId: number;
  response: string;
  schedulingId: number;
  confirm = '';
  computer: Computer;
  show: boolean;
  date: Date = new Date();
  dateNow: string = this.date.getFullYear() + '/' + this.date.getMonth() + '/' + this.date.getDate() + " " + this.date.getHours().toLocaleString() + ":" + this.date.getMinutes();
  schedulingDate: string;
  flag = false;

  constructor(private computerService: ComputerService, private schedulingService: SchedulingService, private http: HttpClient, private datepickerConfig: BsDatepickerConfig, private modalService: BsModalService, private toastr: ToastrService, private titleService: Title, public datepipe: DatePipe) {
    this.titleService.setTitle("Access Console");
		this.datepickerConfig.dateInputFormat = 'DD/MM/YYYY hh:mm';
   }

  ngOnInit() {
    this.getComputers();
  }

  getComputers() {
		this.computerService.getAllComputers().subscribe(
		  (computers: Computer[]) => {
      this.computers = computers; 
    },
		error => {
		  this.toastr.error(error);
		});
  }

  showTerminal(id: number) {
    this.terminal = !this.terminal;
    this.computerId = id;
  }

  executeComand() {
    if (this.comand == null || this.comand == "") {
      this.toastr.error(`Insira um comando válido`);
    }
    else {
      this.scheduling = {comand: this.comand, computerId: this.computerId, schedulingDate: null, executionDate: null, response: null, id: 0};
      if (Date.parse(this.schedulingDate) > new Date().getTime()) {
        this.scheduling.executionDate = this.datepipe.transform(this.schedulingDate, 'yyyy-MM-dd HH:mm', 'UTC -3')
        this.scheduling.schedulingDate = this.datepipe.transform(this.schedulingDate, 'yyyy-MM-dd HH:mm', 'UTC -3')
        this.flag = true;
      } else {
        this.scheduling.executionDate =  this.dateNow;
        this.scheduling.schedulingDate = this.dateNow;
      }
      this.schedulingService.postScheduling(this.scheduling).subscribe(
        (scheduling: Scheduling) => {
          if (this.flag) this.toastr.success(`Comando agendado com sucesso!`);
          else {
            setTimeout(() => {
                this.schedulingService.getScheduling(scheduling.id).subscribe(
                  (scheduling: Scheduling) => {
                    if (scheduling) {
                      this.toastr.success(`Comando executado com sucesso!`);
                      console.log(scheduling);
                      this.response = scheduling.response;
                    } else {
                      this.toastr.error('Execute o console no seu computador');
                    }
                  }
              ); 
            }, 1500);
          }
        },  error => {
          this.toastr.error(`Insira um comando válido`);
        }
      );
    }
  }

  deleteComputer(template: any, computer: Computer) {
    this.openModal(template);
    this.computer = computer;
    this.confirm = `Tem certeza que deseja deletar o computador: ${computer.name}?`;
  }

  openModal(template: any)
  {
    template.show();
  }

  deleteConfirm(template: any) {
    this.computerService.deleteComputer(this.computer.id).subscribe(
      () => {
        template.hide();
        this.getComputers();
        this.toastr.success(`Computador ${this.computer.name} excluído com sucesso!`);
      }, error => {
        this.toastr.error(`Erro ao excluir: ${error}`);
      }
    );
  }
}
