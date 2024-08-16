import {AfterViewInit, Component, OnDestroy, OnInit} from '@angular/core';
import {FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";
import {UserService} from "../../shared/services/user.service";
import {RegionService} from "../../shared/services/region.service";
import {ProvinceService} from "../../shared/services/province.service";
import {Subscription} from "rxjs";
import {Region} from "../../shared/models/Region";
import {Province} from "../../shared/models/Province";
import {Ubigeo} from "../../shared/models/Ubigeo";
import {UbigeoService} from "../../shared/services/ubigeo.service";
import {HotToastService} from "@ngneat/hot-toast";
import {ActivatedRoute, ParamMap, Router} from "@angular/router";
import {User} from "../../shared/models/User";

@Component({
  selector: 'app-usuario-editar',
  templateUrl: './usuario-editar.component.html',
  styleUrls: ['./usuario-editar.component.scss']
})
export class UsuarioEditarComponent implements OnInit, AfterViewInit, OnDestroy {

  formGroup: FormGroup;

  loadingProvince: boolean;
  loadingRegion: boolean;
  loadingUbigeo: boolean;
  loadingSubmit: boolean;

  regionCollection: Region[] = [];
  provinceCollection: Province[] = [];
  ubigeoCollection: Ubigeo[] = [];

  subscriptions: Subscription[] = [];

  usuario: User | undefined;

  constructor(
    private formBuilder: FormBuilder,
    private userService: UserService,
    private regionService: RegionService,
    private provinceService: ProvinceService,
    private ubigeoService: UbigeoService,
    private toast: HotToastService,
    private router: Router,
    private route: ActivatedRoute
  ) {

    this.loadingProvince = true;
    this.loadingRegion = true;
    this.loadingUbigeo = true;
    this.loadingSubmit = true;

    this.formGroup = this.formBuilder.group({
      documentNumber: new FormControl({value: null, disabled: true}, [Validators.required, Validators.maxLength(20)]),
      documentTypeId: new FormControl(null, Validators.required),
      name: new FormControl(null, [Validators.required, Validators.maxLength(100)]),
      fathersLastName: new FormControl(null, [Validators.required, Validators.maxLength(100)]),
      mothersLastName: new FormControl(null, [Validators.required, Validators.maxLength(100)]),
      address: new FormControl(null, [Validators.required, Validators.maxLength(100)]),
      region: new FormControl(null, Validators.required),
      province: new FormControl(null, Validators.required),
      ubigeoCode: new FormControl(null, Validators.required),
      phone: new FormControl(null, [Validators.required, Validators.maxLength(20)]),
      email: new FormControl(null, [Validators.required, Validators.maxLength(20)]),
      password: new FormControl(null, [Validators.required, Validators.maxLength(20)]),
      active: new FormControl(true, Validators.required),
    });

    this.formGroup.get('region')!.valueChanges.subscribe((res)=> {
      if(res){
        this.getProvinceCollectionByRegion(res);
      }
    });
    this.formGroup.get('province')!.valueChanges.subscribe((res)=> {
      if(res){
        this.getUbigeoCollectionByRegionAndProvince(this.f.region.value, res);
      }
    });
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe( (params: ParamMap) => {
      const idUser = params.get('id')!;
      this.getUserById(idUser);
    });

    this.getRegionCollection();
  }

  ngAfterViewInit(): void {
  }

  ngOnDestroy(): void {

    this.subscriptions.forEach(s => s.unsubscribe());

  }

  // Getter
  get f(): any{
    return this.formGroup.controls;
  }

  get model(): any{
    return {
      documentNumber: this.f.documentNumber.value,
      documentTypeId: parseInt(this.f.documentTypeId.value, 10),
      name: this.f.name.value,
      fathersLastName: this.f.fathersLastName.value,
      mothersLastName: this.f.mothersLastName.value,
      address: this.f.address.value,
      ubigeoCode: this.f.ubigeoCode.value,
      phone: this.f.phone.value,
      email: this.f.email.value,
      password: this.f.password.value,
      active: this.f.active.value === 'true',
    }
  }

  // Events
  evtOnSubmit(): void{
    if(this.formGroup.invalid){
      this.toast.error('Debe llenar todos los campos');
      return;
    }

    this.loadingSubmit = true;
    const sub = this.userService.update(this.model).subscribe((res: boolean)=>{
      this.toast.success('Se actualizo los datos del usuario con exito');
      this.loadingSubmit = false;
      this.router.navigate(['/usuario'])
    }, error => {
      this.toast.error('No se pudo actualizar los datos del usuario');
      this.loadingSubmit = false;
    });
    this.subscriptions.push(sub);

  }


  // Data
  getRegionCollection(): void{
    this.loadingRegion = true;
    const subs = this.regionService.collection().subscribe((res: Region[]) => {
      this.regionCollection = res;
      this.loadingRegion = false;
    }, error => {
      this.toast.error('No se pudo obtener el listado de regiones');
      this.loadingRegion = false;
    });
    this.subscriptions.push(subs);
  }

  getProvinceCollectionByRegion(codeRegion: string): void{
    this.loadingProvince = true;
    const subs = this.provinceService.collectionByRegion(codeRegion).subscribe((res: Province[]) => {
      this.provinceCollection = res;
      this.loadingProvince = false;
    }, error => {
      this.toast.error('No se pudo obtener el listado de provincias');
      this.loadingProvince = false;
    });
    this.subscriptions.push(subs);
  }

  getUbigeoCollectionByRegionAndProvince(codeRegion: string, codeProvince: string): void{
    this.loadingUbigeo = true;
    const subs = this.ubigeoService.collectionByRegionAndProvince(codeRegion, codeProvince).subscribe((res: Ubigeo[]) => {
      this.ubigeoCollection = res;
      this.loadingUbigeo = false;
    }, error => {
      this.toast.error('No se pudo obtener el listado de distritos');
      this.loadingUbigeo = false;
    });
    this.subscriptions.push(subs);
  }

  getUserById(id: string): void{
    const subs = this.userService.find(id).subscribe((res: User) => {
      this.usuario = res;
      this.formGroup.patchValue({
        documentNumber: this.usuario.documentNumber,
        documentTypeId: this.usuario.documentTypeId,
        name: this.usuario.name,
        fathersLastName: this.usuario.fathersLastName,
        mothersLastName: this.usuario.mothersLastName,
        address: this.usuario.address,
        region: this.usuario.regionCode,
        province: this.usuario.provinceCode,
        ubigeoCode: this.usuario.ubigeoCode,
        phone: this.usuario.phone,
        email: this.usuario.email,
        password: this.usuario.password,
        active: this.usuario.active,
      });
    }, error => {
      this.toast.error('No se pudo obtener los datos del usuario');
    });
    this.subscriptions.push(subs);
  }


}
