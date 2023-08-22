import { Manager } from "./manager";

export interface Ship {
  id: number;
  shipNumber:number;
  shipName: string;
  createdYear: number;
  shipLength: number;
  shipWidth: number;
  weightGross: number;
  weightNet: number;
  manager?: Manager;
}
