using MQuince.Entities.MedicalRecords;
using MQuince.Repository.SQL.PersistenceEntities.MedicalRecords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MQuince.Repository.SQL.DataProvider.Util
{
    public class RiskFactorMapper
    {
        public static RiskFactor MapRiskFactorPersistenceToRiskFactorEntity(RiskFactorPersistence riskFactor)
        {
            if (riskFactor == null) return null;

            return new RiskFactor(riskFactor.Id, riskFactor.riskFactor);

        }

        public static RiskFactorPersistence MapRiskFactorEntityToRiskFactorPersistence(RiskFactor riskFactor)
        {
            if (riskFactor == null) return null;

            RiskFactorPersistence retVal = new RiskFactorPersistence() { Id = riskFactor.Id, riskFactor = riskFactor.riskFactor };
            return retVal;
        }

        public static IEnumerable<RiskFactor> MapRiskFactorPersistenceCollectionToRiskFactorEntityCollection(IEnumerable<RiskFactorPersistence> clients)
            => clients.Select(c => MapRiskFactorPersistenceToRiskFactorEntity(c));
    }
}
