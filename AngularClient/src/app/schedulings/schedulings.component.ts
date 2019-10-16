import { Component, OnInit } from '@angular/core';
import { Scheduling } from '../models/Scheduling';
import { SchedulingService } from '../services/Scheduling.service';
import { ToastrService } from 'ngx-toastr';
import { BsModalService } from 'ngx-bootstrap';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-schedulings',
  templateUrl: './schedulings.component.html',
  styleUrls: ['./schedulings.component.css']
})
export class SchedulingsComponent implements OnInit {
  title = "Comandos agendados"
  schedulings: Scheduling[] = [];
  scheduling: Scheduling;
  confirm: string;
  computerId: number;
  dateFormat = 'DD/MM/YYYY HH:mm';

  constructor(private schedulingService: SchedulingService, private toastr: ToastrService, private modalService: BsModalService, private router: ActivatedRoute) { }

  ngOnInit() {
    this.getSchedulings(parseInt(this.router.snapshot.paramMap.get('computerId'), 10));
  }

  deleteScheduling(template: any, scheduling: Scheduling) {
    this.openModal(template);
    this.scheduling = scheduling;
    this.confirm = `Tem certeza que deseja deletar agendamento?`;
  }

  deleteConfirm(template: any) {
    this.schedulingService.deleteScheduling(this.scheduling.id).subscribe(
      () => {
        template.hide();
        this.getSchedulings(this.computerId);
        this.toastr.success(`Agendamento exluído com sucesso!`);
      }, error => {
        this.toastr.error(`Erro ao excluir: ${error}`);
      }
    );
  }

  openModal(template: any)
  {
    template.show();
  }

  getSchedulings(computerId: number) {
    this.computerId = computerId;
		this.schedulingService.getSchedulings(computerId).subscribe(
		  (schedulings: Scheduling[]) => {
      this.schedulings = schedulings; 
    },
		error => {
		  this.toastr.error(error);
		});
  }

}
