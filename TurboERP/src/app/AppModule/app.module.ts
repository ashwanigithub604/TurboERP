
import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule }   from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { HttpModule } from '@angular/http';
import { Ng2PaginationModule } from 'ng2-pagination';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { AppComponent }  from '../AppComponents/app.component';
import { MenuComponent } from '../AppComponents/MenuDetails/menu.component';
import { HomeComponent } from '../AppComponents/Home/home.component';
import { GridComponent } from '../AppComponents/GridDetails/grid.component';
import { UnitComponent } from '../AppComponents/UnitMaster/unit.component';
import { FooterComponent } from '../AppComponents/Footer/footer.component';
import { CountryMastComponent } from '../AppComponents/CountryMaster/country.component';
import { ManufacturingUnitComponent } from '../AppComponents/ManufacturingUnit/manufacturing.component';
import {CurrMastComponent} from '../AppComponents/CurrMast/CurrMast.component';
import {ItemGrpComponent} from '../AppComponents/ItemGrp/ItemGrp.component';
import {SkuMastComponent} from '../AppComponents/SkuMast/SkuMast.component';
import {WarehouseComponent} from '../AppComponents/Warehousemast/Warehouse.component';
import { CartPlycomponent } from '../AppComponents/CartonPly/CartPly.component'
import { MiscParty } from '../AppComponents/MiscParty/MiscParty.component';
import { SalesCoordinator } from '../AppComponents/SalesCoOrdinator/SalesCo.component';
import{Couriercomponent} from '../AppComponents/Courier/Courier.component';


const appRoutes: Routes = [
  { path: '', redirectTo: 'Home', pathMatch: 'full' },
  { path: 'Home', component: HomeComponent },
  { path: 'Unit', component: GridComponent},
  { path: 'Unit/Edit', component: UnitComponent},
  { path: 'Unit/Add', component: UnitComponent},
  { path: 'UnitDetails', component: UnitComponent },
  { path: 'CountryMast', component: GridComponent },
  { path: 'CountryMast/Add', component: CountryMastComponent},
  { path: 'CountryMast/Edit', component: CountryMastComponent },
  { path: 'ManufacturingUnit', component: GridComponent },
  { path: 'ManufacturingUnit/Add', component: ManufacturingUnitComponent},
  { path: 'ManufacturingUnit/Edit', component: ManufacturingUnitComponent },
  { path: 'Currency', component: GridComponent},
  { path: 'Currency/Add', component: CurrMastComponent},
  { path: 'Currency/Edit', component: CurrMastComponent},
  { path: 'ItemGrp', component: GridComponent},
  { path: 'ItemGrp/Add', component: ItemGrpComponent},
  { path: 'ItemGrp/Edit', component: ItemGrpComponent},
  { path: 'SkuMast', component: GridComponent},
  { path: 'SkuMast/Add', component: SkuMastComponent},
  { path: 'SkuMast/Edit', component: SkuMastComponent},
  { path: 'Warehouse', component: GridComponent },
  { path: 'Warehouse/Add', component: WarehouseComponent },
  { path: 'Warehouse/Edit', component: WarehouseComponent },
  { path: 'CartonPly', component: GridComponent },
  { path: 'CartonPly/Edit', component: CartPlycomponent },
  { path: 'CartonPly/Add', component: CartPlycomponent },
  { path: 'MiscParty', component: GridComponent },
  { path: 'MiscParty/Edit', component: MiscParty },
  { path: 'MiscParty/Add', component: MiscParty },
  { path: 'SalesCo', component: GridComponent },
  { path: 'SalesCo/Edit', component: SalesCoordinator },
  { path: 'SalesCo/Add', component: SalesCoordinator },
  { path: 'Courier', component: GridComponent },
  { path: 'Courier/Edit', component: SalesCoordinator },
  { path: 'Courier/Add', component: SalesCoordinator },
];
  



@NgModule({
  imports:
  [BrowserModule,Ng2PaginationModule,Ng2SearchPipeModule,
      FormsModule,
      RouterModule.forRoot(
          appRoutes,
    
          {
              enableTracing: true
          }
      ),
      HttpModule,
  ],

  exports: [
      RouterModule
  ],
  declarations: [AppComponent, MenuComponent, HomeComponent,GridComponent,
    UnitComponent,FooterComponent, CountryMastComponent, ManufacturingUnitComponent,
    CurrMastComponent, ItemGrpComponent, SkuMastComponent,WarehouseComponent, CartPlycomponent, MiscParty,
     SalesCoordinator,Couriercomponent],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { 
    
}
