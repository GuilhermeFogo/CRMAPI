import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/Modal/User';
import { ResetsenhaService } from 'src/app/Services/Resetsenha/resetsenha.service';

@Component({
  selector: 'app-form-reset',
  templateUrl: './form-reset.component.html',
  styleUrls: ['./form-reset.component.scss']
})
export class FormResetComponent implements OnInit {

  form!: FormGroup;
  private fb: FormBuilder;
  private readonly ResetsenhaService: ResetsenhaService;
  private readonly rota: Router;

  constructor(fb: FormBuilder, ResetsenhaService: ResetsenhaService, rota: Router) {
    this.fb = fb;
    this.ResetsenhaService = ResetsenhaService
    this.rota = rota;
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      "email": ["", [Validators.email, Validators.required]]
    })
  }

  public get f(): any {
    return this.form.controls;
  }

  public OnSubmit() {
    const user = new User({
      id: 0,
      nome: "",
      senha: "",
      role: 0,
      email: this.f.email.value,
      ativado: false
    });

    this.PostResetsenha(user);
  }

  private PostResetsenha(user: User): any {
    this.ResetsenhaService.PostEmail(user).subscribe({
      next: () => {
        this.rota.navigateByUrl("");
      },
      error: () => {
        this.rota.navigateByUrl("");    
      }
    })
  }
}

