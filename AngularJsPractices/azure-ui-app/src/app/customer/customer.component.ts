import { Component, OnInit } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-customer',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {
  private apiUrl = 'https://localhost:7261/api/Customers/CreateCustomer';
  customerForm: any;   // declare first

  constructor(private fb: FormBuilder, private http: HttpClient) {}

  ngOnInit() {
    this.customerForm = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      state: ['', Validators.required],
      country: ['', Validators.required],
      zipCode: [
        '',
        [
          Validators.required,
          Validators.minLength(5),
          Validators.maxLength(6),
          Validators.pattern(/^[0-9]+$/)
        ]
      ],
      phone: [
        '',
        [
          Validators.required,
          Validators.maxLength(12),
          Validators.pattern(/^[0-9]+$/)
        ]
      ]
    });
  }

  onSubmit() {
    if (this.customerForm.valid) {
      this.http.post<any>(this.apiUrl, this.customerForm.value).subscribe({
        next: (res) => {
          alert(`Customer Created! ID: ${res.customerId}`);
        },
        error: (err) => {
          console.error(err);
          alert('Failed to create customer');
        }
      });
    }
  }
}
