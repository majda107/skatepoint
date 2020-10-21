import { ProvinceInfectionModel } from './province-infection-model';
import { SchoolModel } from './school-model';

export interface SchoolInfectionModel {
    school: SchoolModel
    notice: string,
    infections: ProvinceInfectionModel[],
    level: "low" | "high" | "none"
}