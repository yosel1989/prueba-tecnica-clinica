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

@Component({
  selector: 'app-usuario-nuevo',
  templateUrl: './usuario-nuevo.component.html',
  styleUrls: ['./usuario-nuevo.component.scss']
})
export class UsuarioNuevoComponent implements OnInit, AfterViewInit, OnDestroy {

  formGroup: FormGroup;

  loadingProvince: boolean;
  loadingRegion: boolean;
  loadingUbigeo: boolean;

  regionCollection: Region[] = [];
  provinceCollection: Province[] = [];
  ubigeoCollection: Ubigeo[] = [];

  subscriptions: Subscription[] = [];

  constructor(
    private formBuilder: FormBuilder,
    private userService: UserService,
    private regionService: RegionService,
    private provinceService: ProvinceService,
    private ubigeoService: UbigeoService,
    private toast: HotToastService
  ) {

    this.loadingProvince = true;
    this.loadingRegion = true;
    this.loadingUbigeo = true;

    this.formGroup = this.formBuilder.group({
        'documentNumber': new FormControl(null, [Validators.required, Validators.maxLength(20)]),
        'documentTypeId': new FormControl(null, Validators.required),
        'name': new FormControl(null, [Validators.required, Validators.maxLength(100)]),
        'fathersLastName': new FormControl(null, [Validators.required, Validators.maxLength(100)]),
        'mothersLastName': new FormControl(null, [Validators.required, Validators.maxLength(100)]),
        'address': new FormControl(null, [Validators.required, Validators.maxLength(100)]),
        'region': new FormControl(null, Validators.required),
        'province': new FormControl(null, Validators.required),
        'ubigeoCode': new FormControl(null, Validators.required),
        'phone': new FormControl(null, [Validators.required, Validators.maxLength(20)]),
        'email': new FormControl(null, [Validators.required, Validators.maxLength(20)]),
        'password': new FormControl(null, [Validators.required, Validators.maxLength(20)]),
        'active': new FormControl(true, Validators.required),
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

  // Events
  evtOnSubmit(): void{

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


}
