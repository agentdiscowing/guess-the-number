import { FormGroup, ValidatorFn} from '@angular/forms';

export function mustMatchValidator(mainField: string, matchingField: string): ValidatorFn {
    return (formGroup: FormGroup): {[key: string]: any} | null => {
        const control = formGroup.controls[mainField];
        const matchingControl = formGroup.controls[matchingField];
        if (matchingControl.errors && !matchingControl.errors.mustMatch) {
            return;
        }
        if (control.value !== matchingControl.value) {
            matchingControl.setErrors({ mustMatch: true });
        } else {
            matchingControl.setErrors(null);
        }
    }
  }