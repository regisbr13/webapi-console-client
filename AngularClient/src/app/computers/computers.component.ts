import { Component, OnInit } from '@angular/core';
import { ComputerService } from '../services/Computer.service';
import { Computer } from '../models/Computer';
import { Scheduling } from '../models/Scheduling';
import { SchedulingService } from '../services/Scheduling.service';
import { HttpClient } from '@angular/common/http';
import { defineLocale, BsLocaleService, ptBrLocale, BsDatepickerConfig, BsModalService } from 'ngx-bootstrap';
import { debounceTime } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';

defineLocale('pt-br', ptBrLocale);

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
  animation: string;
  confirm = '';
  computer: Computer;
  show: boolean;
  date: Date = new Date();
  dateNow: string = this.date.getFullYear() + '/' + this.date.getMonth() + '/' + this.date.getDate() + " " + this.date.getHours().toLocaleString() + ":" + this.date.getMinutes();
  schedulingDate: string;
  notification: string;

  constructor(private computerService: ComputerService, private schedulingService: SchedulingService, private http: HttpClient, private datepickerConfig: BsDatepickerConfig, private localeService: BsLocaleService, private modalService: BsModalService, private toastr: ToastrService) {
    this.localeService.use('pt-br');
		this.datepickerConfig.dateInputFormat = 'YYYY/MM/DD hh:mm';
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
    this.scheduling = {comand: this.comand, computerId: this.computerId, computer: null, schedulingDate: null, executionDate: null, response: null, id: 0};
    if(this.schedulingDate) {
      this.scheduling.executionDate = this.schedulingDate;
      this.scheduling.schedulingDate = this.schedulingDate;
      this.notification = `Comando agendado com sucesso!`;
    } else {
      this.scheduling.executionDate =  this.dateNow;
      this.scheduling.schedulingDate = this.dateNow;
      this.notification = `Comando executado com sucesso!`;
    }
    this.schedulingService.postScheduling(this.scheduling).subscribe(
      (scheduling: Scheduling) => {
        setTimeout(() => {
            this.schedulingService.getScheduling(scheduling.id).subscribe(
              (scheduling: Scheduling) => {
                if (scheduling.response) {
                  this.toastr.success(this.notification)
                } else {
                  this.toastr.error('Execute o console no seu computador');
                }
              }
          ); 
        }, 1500);
      }
    );
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
        this.toastr.success(`Computador ${this.computer.name} exluído com sucesso!`);
      }, error => {
        this.toastr.error(`Erro ao excluir: ${error}`);
      }
    );
  }
}
